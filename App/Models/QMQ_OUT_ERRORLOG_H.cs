using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class QMQ_OUT_ERRORLOG_H
    {
        public string SOURCE { get; set; }
        public string MESSAGE_ID { get; set; }
        public string DATE_TIME_ERROR { get; set; }
        public string ERROR_TEXT { get; set; }

        public virtual QMQ_OUT_HEADER QMQ_OUT_HEADER { get; set; }
    }
}
