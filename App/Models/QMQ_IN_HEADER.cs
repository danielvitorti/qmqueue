using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class QMQ_IN_HEADER : JqueryDataTablesParameters
    {
        public QMQ_IN_HEADER()
        {
            QMQ_IN_BODY_Hs = new HashSet<QMQ_IN_BODY_H>();
            QMQ_IN_BODies = new HashSet<QMQ_IN_BODY>();
            QMQ_IN_ERRORLOG_Hs = new HashSet<QMQ_IN_ERRORLOG_H>();
            QMQ_IN_ERRORLOGs = new HashSet<QMQ_IN_ERRORLOG>();
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

        public virtual ICollection<QMQ_IN_BODY_H> QMQ_IN_BODY_Hs { get; set; }
        public virtual ICollection<QMQ_IN_BODY> QMQ_IN_BODies { get; set; }
        public virtual ICollection<QMQ_IN_ERRORLOG_H> QMQ_IN_ERRORLOG_Hs { get; set; }
        public virtual ICollection<QMQ_IN_ERRORLOG> QMQ_IN_ERRORLOGs { get; set; }
    }
}
