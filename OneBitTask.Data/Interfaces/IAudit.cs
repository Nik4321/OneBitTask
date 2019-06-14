using System;

namespace OneBitTask.Data.Interfaces
{
    public interface IAudit
    {
        DateTime Created { get; set; }
    }
}