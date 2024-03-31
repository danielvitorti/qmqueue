using Microsoft.EntityFrameworkCore.Migrations;

namespace QMessage.Migrations
{
    public partial class AlteracaoEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QMQ_IN_BODY");

            migrationBuilder.DropTable(
                name: "QMQ_IN_BODY_H");

            migrationBuilder.DropTable(
                name: "QMQ_IN_ERRORLOG");

            migrationBuilder.DropTable(
                name: "QMQ_IN_ERRORLOG_H");

            migrationBuilder.DropTable(
                name: "QMQ_OUT_BODY");

            migrationBuilder.DropTable(
                name: "QMQ_OUT_BODY_H");

            migrationBuilder.DropTable(
                name: "QMQ_OUT_ERRORLOG");

            migrationBuilder.DropTable(
                name: "QMQ_OUT_ERRORLOG_H");

            migrationBuilder.DropTable(
                name: "QMQDb");

            migrationBuilder.DropTable(
                name: "QmqInBody");

            migrationBuilder.DropTable(
                name: "QmqInBodyH");

            migrationBuilder.DropTable(
                name: "QmqInErrorlog");

            migrationBuilder.DropTable(
                name: "QmqInErrorlogH");

            migrationBuilder.DropTable(
                name: "QmqOutBody");

            migrationBuilder.DropTable(
                name: "QmqOutBodyH");

            migrationBuilder.DropTable(
                name: "QmqOutErrorlog");

            migrationBuilder.DropTable(
                name: "QmqOutErrorlogH");

            migrationBuilder.DropTable(
                name: "QMQ_IN_HEADER");

            migrationBuilder.DropTable(
                name: "QMQ_OUT_HEADER");

            migrationBuilder.DropTable(
                name: "QmqInHeader");

            migrationBuilder.DropTable(
                name: "QmqOutHeader");

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

            migrationBuilder.CreateTable(
                name: "QMQ_IN_HEADER",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME_IN = table.Column<string>(type: "TEXT", nullable: true),
                    DATE_TIME_PROC = table.Column<string>(type: "TEXT", nullable: true),
                    EXPIRATION_TIME = table.Column<string>(type: "TEXT", nullable: true),
                    MESSAGE_TYPE = table.Column<string>(type: "TEXT", nullable: true),
                    MSG_STATUS = table.Column<string>(type: "CHAR(1)", nullable: true),
                    REMARKS = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    RETRY_COUNT = table.Column<long>(type: "INTEGER", nullable: true),
                    TARGET = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_IN_HEADER", x => new { x.SOURCE, x.MESSAGE_ID });
                });

            migrationBuilder.CreateTable(
                name: "QMQ_OUT_HEADER",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME_IN = table.Column<string>(type: "TEXT", nullable: true),
                    DATE_TIME_PROC = table.Column<string>(type: "TEXT", nullable: true),
                    EXPIRATION_TIME = table.Column<string>(type: "TEXT", nullable: true),
                    MESSAGE_TYPE = table.Column<string>(type: "TEXT", nullable: true),
                    MSG_STATUS = table.Column<string>(type: "CHAR(1)", nullable: true),
                    REMARKS = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    RETRY_COUNT = table.Column<long>(type: "INTEGER", nullable: true),
                    TARGET = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_OUT_HEADER", x => new { x.SOURCE, x.MESSAGE_ID });
                });

            migrationBuilder.CreateTable(
                name: "QMQDb",
                columns: table => new
                {
                    Telegramm = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    FieldSeq = table.Column<long>(type: "INTEGER", nullable: false),
                    Feature = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ColumnName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Factor = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    TableName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Type = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQDb", x => new { x.Telegramm, x.FieldSeq, x.Feature });
                });

            migrationBuilder.CreateTable(
                name: "QmqInHeader",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateTimeProc = table.Column<string>(type: "TEXT", nullable: true),
                    ExpirationTime = table.Column<string>(type: "TEXT", nullable: true),
                    MessageType = table.Column<string>(type: "TEXT", nullable: true),
                    MsgStatus = table.Column<string>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    RetryCount = table.Column<long>(type: "INTEGER", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Target = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqInHeader", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "QmqOutHeader",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateTimeProc = table.Column<string>(type: "TEXT", nullable: true),
                    ExpirationTime = table.Column<string>(type: "TEXT", nullable: true),
                    MessageType = table.Column<string>(type: "TEXT", nullable: true),
                    MsgStatus = table.Column<string>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    RetryCount = table.Column<long>(type: "INTEGER", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Target = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqOutHeader", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_IN_BODY",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    FIELD_SEQ = table.Column<long>(type: "INTEGER", nullable: false),
                    FEATURE = table.Column<string>(type: "CHAR(40)", nullable: true),
                    VALUE = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_IN_BODY", x => new { x.SOURCE, x.MESSAGE_ID, x.FIELD_SEQ });
                    table.ForeignKey(
                        name: "FK_QMQ_IN_BODY_QMQ_IN_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_IN_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_IN_BODY_H",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    FIELD_SEQ = table.Column<long>(type: "INTEGER", nullable: false),
                    FEATURE = table.Column<string>(type: "CHAR(40)", nullable: true),
                    VALUE = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_IN_BODY_H", x => new { x.SOURCE, x.MESSAGE_ID, x.FIELD_SEQ });
                    table.ForeignKey(
                        name: "FK_QMQ_IN_BODY_H_QMQ_IN_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_IN_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_IN_ERRORLOG",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME_ERROR = table.Column<string>(type: "TEXT", nullable: false),
                    ERROR_TEXT = table.Column<string>(type: "VARCHAR(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_IN_ERRORLOG", x => new { x.SOURCE, x.MESSAGE_ID, x.DATE_TIME_ERROR });
                    table.ForeignKey(
                        name: "FK_QMQ_IN_ERRORLOG_QMQ_IN_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_IN_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_IN_ERRORLOG_H",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME_ERROR = table.Column<string>(type: "TEXT", nullable: false),
                    ERROR_TEXT = table.Column<string>(type: "VARCHAR(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_IN_ERRORLOG_H", x => new { x.SOURCE, x.MESSAGE_ID, x.DATE_TIME_ERROR });
                    table.ForeignKey(
                        name: "FK_QMQ_IN_ERRORLOG_H_QMQ_IN_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_IN_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_OUT_BODY",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    FIELD_SEQ = table.Column<long>(type: "INTEGER", nullable: false),
                    FEATURE = table.Column<string>(type: "CHAR(40)", nullable: true),
                    VALUE = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_OUT_BODY", x => new { x.SOURCE, x.MESSAGE_ID, x.FIELD_SEQ });
                    table.ForeignKey(
                        name: "FK_QMQ_OUT_BODY_QMQ_OUT_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_OUT_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_OUT_BODY_H",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    FIELD_SEQ = table.Column<long>(type: "INTEGER", nullable: false),
                    FEATURE = table.Column<string>(type: "CHAR(40)", nullable: true),
                    VALUE = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_OUT_BODY_H", x => new { x.SOURCE, x.MESSAGE_ID, x.FIELD_SEQ });
                    table.ForeignKey(
                        name: "FK_QMQ_OUT_BODY_H_QMQ_OUT_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_OUT_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_OUT_ERRORLOG",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME_ERROR = table.Column<string>(type: "TEXT", nullable: false),
                    ERROR_TEXT = table.Column<string>(type: "VARCHAR(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_OUT_ERRORLOG", x => new { x.SOURCE, x.MESSAGE_ID, x.DATE_TIME_ERROR });
                    table.ForeignKey(
                        name: "FK_QMQ_OUT_ERRORLOG_QMQ_OUT_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_OUT_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QMQ_OUT_ERRORLOG_H",
                columns: table => new
                {
                    SOURCE = table.Column<string>(type: "TEXT", nullable: false),
                    MESSAGE_ID = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_TIME_ERROR = table.Column<string>(type: "TEXT", nullable: false),
                    ERROR_TEXT = table.Column<string>(type: "VARCHAR(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QMQ_OUT_ERRORLOG_H", x => new { x.SOURCE, x.MESSAGE_ID, x.DATE_TIME_ERROR });
                    table.ForeignKey(
                        name: "FK_QMQ_OUT_ERRORLOG_H_QMQ_OUT_HEADER_SOURCE_MESSAGE_ID",
                        columns: x => new { x.SOURCE, x.MESSAGE_ID },
                        principalTable: "QMQ_OUT_HEADER",
                        principalColumns: new[] { "SOURCE", "MESSAGE_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqInBody",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    Feature = table.Column<string>(type: "TEXT", nullable: true),
                    FieldSeq = table.Column<long>(type: "INTEGER", nullable: false),
                    QmqInHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqInBody", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqInBody_QmqInHeader_QmqInHeaderMessageId",
                        column: x => x.QmqInHeaderMessageId,
                        principalTable: "QmqInHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqInBodyH",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    Feature = table.Column<string>(type: "TEXT", nullable: true),
                    FieldSeq = table.Column<long>(type: "INTEGER", nullable: false),
                    QmqInHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqInBodyH", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqInBodyH_QmqInHeader_QmqInHeaderMessageId",
                        column: x => x.QmqInHeaderMessageId,
                        principalTable: "QmqInHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqInErrorlog",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeError = table.Column<string>(type: "TEXT", nullable: true),
                    ErrorText = table.Column<string>(type: "TEXT", nullable: true),
                    QmqInHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqInErrorlog", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqInErrorlog_QmqInHeader_QmqInHeaderMessageId",
                        column: x => x.QmqInHeaderMessageId,
                        principalTable: "QmqInHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqInErrorlogH",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeError = table.Column<string>(type: "TEXT", nullable: true),
                    ErrorText = table.Column<string>(type: "TEXT", nullable: true),
                    QmqInHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqInErrorlogH", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqInErrorlogH_QmqInHeader_QmqInHeaderMessageId",
                        column: x => x.QmqInHeaderMessageId,
                        principalTable: "QmqInHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqOutBody",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    Feature = table.Column<string>(type: "TEXT", nullable: true),
                    FieldSeq = table.Column<long>(type: "INTEGER", nullable: false),
                    QmqOutHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqOutBody", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqOutBody_QmqOutHeader_QmqOutHeaderMessageId",
                        column: x => x.QmqOutHeaderMessageId,
                        principalTable: "QmqOutHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqOutBodyH",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    Feature = table.Column<string>(type: "TEXT", nullable: true),
                    FieldSeq = table.Column<long>(type: "INTEGER", nullable: false),
                    QmqOutHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqOutBodyH", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqOutBodyH_QmqOutHeader_QmqOutHeaderMessageId",
                        column: x => x.QmqOutHeaderMessageId,
                        principalTable: "QmqOutHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqOutErrorlog",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeError = table.Column<string>(type: "TEXT", nullable: true),
                    ErrorText = table.Column<string>(type: "TEXT", nullable: true),
                    QmqOutHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqOutErrorlog", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqOutErrorlog_QmqOutHeader_QmqOutHeaderMessageId",
                        column: x => x.QmqOutHeaderMessageId,
                        principalTable: "QmqOutHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QmqOutErrorlogH",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeError = table.Column<string>(type: "TEXT", nullable: true),
                    ErrorText = table.Column<string>(type: "TEXT", nullable: true),
                    QmqOutHeaderMessageId = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QmqOutErrorlogH", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_QmqOutErrorlogH_QmqOutHeader_QmqOutHeaderMessageId",
                        column: x => x.QmqOutHeaderMessageId,
                        principalTable: "QmqOutHeader",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QmqInBody_QmqInHeaderMessageId",
                table: "QmqInBody",
                column: "QmqInHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqInBodyH_QmqInHeaderMessageId",
                table: "QmqInBodyH",
                column: "QmqInHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqInErrorlog_QmqInHeaderMessageId",
                table: "QmqInErrorlog",
                column: "QmqInHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqInErrorlogH_QmqInHeaderMessageId",
                table: "QmqInErrorlogH",
                column: "QmqInHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqOutBody_QmqOutHeaderMessageId",
                table: "QmqOutBody",
                column: "QmqOutHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqOutBodyH_QmqOutHeaderMessageId",
                table: "QmqOutBodyH",
                column: "QmqOutHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqOutErrorlog_QmqOutHeaderMessageId",
                table: "QmqOutErrorlog",
                column: "QmqOutHeaderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_QmqOutErrorlogH_QmqOutHeaderMessageId",
                table: "QmqOutErrorlogH",
                column: "QmqOutHeaderMessageId");
        }
    }
}
