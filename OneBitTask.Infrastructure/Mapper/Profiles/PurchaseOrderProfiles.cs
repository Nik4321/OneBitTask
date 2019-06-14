using AutoMapper;
using OneBitTask.Data.Entities;
using OneBitTask.ViewModels.PurchaseOrder;

namespace OneBitTask.Infrastructure.Mapper.Profiles
{
    public class PurchaseOrderProfiles : Profile
    {
        public PurchaseOrderProfiles()
        {
            CreateMap<AddPurchaseOrderViewModel, PurchaseOrder>();

            CreateMap<EditPurchaseOrderViewModel, PurchaseOrder>()
                .ReverseMap();
        }
    }
}
