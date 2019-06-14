using System.Collections.Generic;

namespace OneBitTask.ViewModels.Shared
{
    public class DataTableResponseViewModel<T>
    {
        public int Draw { get; set; }

        public int RecordsTotal { get; set; }

        public int RecordsFiltered { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
