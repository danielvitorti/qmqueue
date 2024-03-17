using System;
using System.Collections.Generic;

#nullable disable

namespace QMessage.Models
{
    public partial class QMQ_IN_BODY_H
    {
        public string SOURCE { get; set; }
        public string MESSAGE_ID { get; set; }
        public long FIELD_SEQ { get; set; }
        public string FEATURE { get; set; }
        public string VALUE { get; set; }

        public virtual QMQ_IN_HEADER QMQ_IN_HEADER { get; set; }
    }
}
