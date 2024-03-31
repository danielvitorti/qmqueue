using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class QMQ_IN_HEADER : JqueryDataTablesParameters
    {
        public QMQ_IN_HEADER()
        {
            QMQ_IN_BODies = new HashSet<QMQ_IN_BODY>();
        }

        public string SOURCE { get; set; }
        public string MESSAGE_ID { get; set; }
        public string TARGET { get; set; }
        public string MESSAGE_TYPE { get; set; }
        public string EXPIRATION_TIME { get; set; }
        public string REMARKS { get; set; }
        public string MSG_STATUS { get; set; }
        public string DATE_TIME_IN { get; set; }
        public string DATE_TIME_PROC { get; set; }
        public long? RETRY_COUNT { get; set; }

        public virtual ICollection<QMQ_IN_BODY> QMQ_IN_BODies { get; set; }
        
    }
}
