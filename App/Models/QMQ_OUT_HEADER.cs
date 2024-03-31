using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class QMQ_OUT_HEADER : JqueryDataTablesParameters
    {
        public QMQ_OUT_HEADER()
        {
            QMQ_OUT_BODies = new HashSet<QMQ_OUT_BODY>();
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

        public virtual ICollection<QMQ_OUT_BODY> QMQ_OUT_BODies { get; set; }
    }
}
