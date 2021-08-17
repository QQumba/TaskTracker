using System;

namespace Domain.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
    }
}