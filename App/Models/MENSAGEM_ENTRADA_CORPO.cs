using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class MENSAGEM_ENTRADA_CORPO: JqueryDataTablesParameters
    {
        public string SISTEMA_ORIGEM { get; set; }
        public string ID_MENSAGEM { get; set; }
        public long SEQUENCIAL { get; set; }
        public string CAMPO { get; set; }
        public string VALOR { get; set; }

        public virtual MENSAGEM_ENTRADA_CABECALHO mensagemEntradaCabecalho { get; set; }
    }
}
