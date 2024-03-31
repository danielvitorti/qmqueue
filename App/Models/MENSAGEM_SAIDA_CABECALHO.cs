using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class MENSAGEM_SAIDA_CABECALHO : JqueryDataTablesParameters
    {
        public MENSAGEM_SAIDA_CABECALHO()
        {
            mensagemSaidaCorpo = new HashSet<MENSAGEM_SAIDA_CORPO>();
        }

        public string SISTEMA_ORIGEM { get; set; }
        public string ID_MENSAGEM { get; set; }
        public string SISTEMA_DESTINO { get; set; }
        public string CODIGO_MENSAGEM { get; set; }
        public string OBSERVACAO { get; set; }
        public string STATUS { get; set; }
        public string DATA_PROCESSAMENTO { get; set; }
        
        public virtual ICollection<MENSAGEM_SAIDA_CORPO> mensagemSaidaCorpo { get; set; }
    }
}
