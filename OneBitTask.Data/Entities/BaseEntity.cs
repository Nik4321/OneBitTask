using System;
using OneBitTask.Data.Enums;
using OneBitTask.Data.Interfaces;

namespace OneBitTask.Data.Entities
{
    public class BaseEntity : IAudit
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public EntityStatus Status { get; set; }
    }
}
