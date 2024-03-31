using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly QMessageDbContext _dbContext;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, QMessageDbContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // Realize o polling na tabela xqi_in_header aqui
                var headers = await _dbContext.XqiInHeaders.ToListAsync();

                // Exemplo: Mostrar informações dos cabeçalhos no log
                foreach (var header in headers)
                {
                    _logger.LogInformation("HeaderId: {headerId}, Description: {description}", header.HeaderId, header.Description);
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Intervalo de polling de 10 segundos
            }
        }
    }
}
