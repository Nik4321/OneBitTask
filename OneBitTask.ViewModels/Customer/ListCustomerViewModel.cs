using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OneBitTask.Data.Enums;

namespace OneBitTask.ViewModels.Customer
{
    public class ListCustomerViewModel
    {
        public int Id { get; set; }

        public string Created { get; set; }

        public EntityStatus Status { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Sex { get; set; }

        public string Telephone { get; set; }
    }
}
