using Microsoft.EntityFrameworkCore.Migrations;

namespace QMessage.Migrations
{
    public partial class InitialQueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MENSAGEM_ENTRADA_CABECALHO",
                columns: table => new
                {
                    SISTEMA_ORIGEM = table.Column<string>(type: "TEXT", nullable: false),
                    ID_MENSAGEM = table.Column<string>(type: "TEXT", nullable: false),
                    SISTEMA_DESTINO = table.Column<string>(type: "TEXT", nullable: true),
                    CODIGO_MENSAGEM = table.Column<string>(type: "TEXT", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    STATUS = table.Column<string>(type: "CHAR(1)", nullable: true),
                    DATA_PROCESSAMENTO = table.Column<string>(type: "TEXT", nullable: true),
                    sEcho = table.Column<string>(type: "TEXT", nullable: true),
                    sSearch = table.Column<string>(type: "TEXT", nullable: true),
                    iDisplayLength = table.Column<int>(type: "INTEGER", nullable: false),
                    iDisplayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    iColumns = table.Column<int>(type: "INTEGER", nullable: false),
                    iSortCol_0 = table.Column<int>(type: "INTEGER", nullable: false),
                    sSortDir_0 = table.Column<string>(type: "TEXT", nullable: true),
                    iSortingCols = table.Column<int>(type: "INTEGER", nullable: false),
                    sColumns = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGEM_ENTRADA_CABECALHO", x => new { x.SISTEMA_ORIGEM, x.ID_MENSAGEM });
                });

            migrationBuilder.CreateTable(
                name: "MENSAGEM_SAIDA_CABECALHO",
                columns: table => new
                {
                    ID_MENSAGEM = table.Column<string>(type: "TEXT", nullable: false),
                    SISTEMA_DESTINO = table.Column<string>(type: "TEXT", nullable: false),
                    SISTEMA_ORIGEM = table.Column<string>(type: "TEXT", nullable: true),
                    CODIGO_MENSAGEM = table.Column<string>(type: "TEXT", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    STATUS = table.Column<string>(type: "CHAR(1)", nullable: true),
                    DATA_PROCESSAMENTO = table.Column<string>(type: "TEXT", nullable: true),
                    sEcho = table.Column<string>(type: "TEXT", nullable: true),
                    sSearch = table.Column<string>(type: "TEXT", nullable: true),
                    iDisplayLength = table.Column<int>(type: "INTEGER", nullable: false),
                    iDisplayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    iColumns = table.Column<int>(type: "INTEGER", nullable: false),
                    iSortCol_0 = table.Column<int>(type: "INTEGER", nullable: false),
                    sSortDir_0 = table.Column<string>(type: "TEXT", nullable: true),
                    iSortingCols = table.Column<int>(type: "INTEGER", nullable: false),
                    sColumns = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGEM_SAIDA_CABECALHO", x => new { x.SISTEMA_DESTINO, x.ID_MENSAGEM });
                });

            migrationBuilder.CreateTable(
                name: "MENSAGEM_ENTRADA_CORPO",
                columns: table => new
                {
                    SISTEMA_ORIGEM = table.Column<string>(type: "TEXT", nullable: false),
                    ID_MENSAGEM = table.Column<string>(type: "TEXT", nullable: false),
                    SEQUENCIAL = table.Column<long>(type: "INTEGER", nullable: false),
                    CAMPO = table.Column<string>(type: "CHAR(40)", nullable: true),
                    VALOR = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    sEcho = table.Column<string>(type: "TEXT", nullable: true),
                    sSearch = table.Column<string>(type: "TEXT", nullable: true),
                    iDisplayLength = table.Column<int>(type: "INTEGER", nullable: false),
                    iDisplayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    iColumns = table.Column<int>(type: "INTEGER", nullable: false),
                    iSortCol_0 = table.Column<int>(type: "INTEGER", nullable: false),
                    sSortDir_0 = table.Column<string>(type: "TEXT", nullable: true),
                    iSortingCols = table.Column<int>(type: "INTEGER", nullable: false),
                    sColumns = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGEM_ENTRADA_CORPO", x => new { x.SISTEMA_ORIGEM, x.ID_MENSAGEM, x.SEQUENCIAL });
                    table.ForeignKey(
                        name: "FK_MENSAGEM_ENTRADA_CORPO_MENSAGEM_ENTRADA_CABECALHO_SISTEMA_ORIGEM_ID_MENSAGEM",
                        columns: x => new { x.SISTEMA_ORIGEM, x.ID_MENSAGEM },
                        principalTable: "MENSAGEM_ENTRADA_CABECALHO",
                        principalColumns: new[] { "SISTEMA_ORIGEM", "ID_MENSAGEM" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MENSAGEM_SAIDA_CORPO",
                columns: table => new
                {
                    SISTEMA_ORIGEM = table.Column<string>(type: "TEXT", nullable: false),
                    ID_MENSAGEM = table.Column<string>(type: "TEXT", nullable: false),
                    SEQUENCIAL = table.Column<long>(type: "INTEGER", nullable: false),
                    CAMPO = table.Column<string>(type: "CHAR(40)", nullable: true),
                    VALOR = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    sEcho = table.Column<string>(type: "TEXT", nullable: true),
                    sSearch = table.Column<string>(type: "TEXT", nullable: true),
                    iDisplayLength = table.Column<int>(type: "INTEGER", nullable: false),
                    iDisplayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    iColumns = table.Column<int>(type: "INTEGER", nullable: false),
                    iSortCol_0 = table.Column<int>(type: "INTEGER", nullable: false),
                    sSortDir_0 = table.Column<string>(type: "TEXT", nullable: true),
                    iSortingCols = table.Column<int>(type: "INTEGER", nullable: false),
                    sColumns = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGEM_SAIDA_CORPO", x => new { x.SISTEMA_ORIGEM, x.ID_MENSAGEM, x.SEQUENCIAL });
                    table.ForeignKey(
                        name: "FK_MENSAGEM_SAIDA_CORPO_MENSAGEM_SAIDA_CABECALHO_SISTEMA_ORIGEM_ID_MENSAGEM",
                        columns: x => new { x.SISTEMA_ORIGEM, x.ID_MENSAGEM },
                        principalTable: "MENSAGEM_SAIDA_CABECALHO",
                        principalColumns: new[] { "SISTEMA_DESTINO", "ID_MENSAGEM" },
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MENSAGEM_ENTRADA_CORPO");

            migrationBuilder.DropTable(
                name: "MENSAGEM_SAIDA_CORPO");

            migrationBuilder.DropTable(
                name: "MENSAGEM_ENTRADA_CABECALHO");

            migrationBuilder.DropTable(
                name: "MENSAGEM_SAIDA_CABECALHO");
        }
    }
}
