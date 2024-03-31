using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly QMessageDbContext _dbContext;

        public Worker(ILogger<Worker> logger, QMessageDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // Realize o polling na tabela MENSAGEM_ENTRADA_CABECALHO aqui
                string connectionString = "";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    try{
                    string selectQuery = "SELECT * FROM MENSAGEM_SAIDA_CABECALHO WHERE STATUS = 'N'";
                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Obter os dados da linha
                                string sistemaOrigem = reader["SISTEMA_ORIGEM"].ToString();
                                string idMensagem = reader["ID_MENSAGEM"].ToString();
                                string sistemaDestino = reader["SISTEMA_DESTINO"].ToString();
                                // E assim por diante para os outros campos

                                // Inserir os dados na nova tabela
                                string insertQuery = "INSERT INTO MENSAGEM_SAIDA_CABECALHO_NOVO (SISTEMA_ORIGEM, ID_MENSAGEM, SISTEMA_DESTINO, ...) VALUES (@SISTEMA_ORIGEM, @ID_MENSAGEM, @SISTEMA_DESTINO, ...)";
                                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@SISTEMA_ORIGEM", sistemaOrigem);
                                    insertCommand.Parameters.AddWithValue("@ID_MENSAGEM", idMensagem);
                                    insertCommand.Parameters.AddWithValue("@SISTEMA_DESTINO", sistemaDestino);
                                    // E assim por diante para os outros campos
                                    insertCommand.ExecuteNonQuery();
                                }
                                // Atualiza para mensagem processada
                                string updateQuery = $"UDPATE MENSAGEM_SAIDA_CABECALHO SET status = 'P' "+
                                                     $"where SISTEMA_ORIGEM ='{sistemaOrigem}' and ID_MENSAGEM = '{idMensagem}' ";
                                using (SQLiteCommand updateCommand = new SQLiteCommand(updateCommand,connection))
                                {
                                    updateCommand.ExecuteNonQuery();
                                } 
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // Intervalo de polling de 5 segundos
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.AddConsole();
                });

            await builder.RunConsoleAsync();
        }
    }
}
