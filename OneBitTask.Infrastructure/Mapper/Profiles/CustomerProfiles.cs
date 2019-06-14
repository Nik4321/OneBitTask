using System;
using AutoMapper;
using OneBitTask.Data.Entities;
using OneBitTask.ViewModels.Customer;

namespace OneBitTask.Infrastructure.Mapper.Profiles
{
    public class CustomerProfiles : Profile
    {
        public CustomerProfiles()
        {
            CreateMap<Customer, ListCustomerViewModel>()
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created.ToShortDateString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => string.Concat(s.FirstName, " ", s.LastName)));

            CreateMap<Customer, DetailsCustomerViewModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => string.Concat(s.FirstName, " ", s.LastName)));

            CreateMap<AddCustomerViewModel, Customer>();

            CreateMap<EditCustomerViewModel, Customer>()
                .ReverseMap();
        }
    }
}
