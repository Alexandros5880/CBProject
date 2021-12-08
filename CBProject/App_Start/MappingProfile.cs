using AutoMapper;
using CBProject.Models;
using CBProject.Models.EntityModel;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CBProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<IdentityRole, IdentityRoleViewModel>();
            Mapper.CreateMap<IdentityRoleViewModel, IdentityRole>();

            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();

            Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>();
            Mapper.CreateMap<ApplicationUserViewModel, ApplicationUser>();

            Mapper.CreateMap<ICollection<IdentityRole>, ICollection<IdentityRoleViewModel>>();
            Mapper.CreateMap<ICollection<IdentityRoleViewModel>, ICollection<IdentityRole>>();

            Mapper.CreateMap<ICollection<ApplicationUser>, ICollection<RegisterViewModel>>();
            Mapper.CreateMap<ICollection<RegisterViewModel>, ICollection<ApplicationUser>>();

            Mapper.CreateMap<ICollection<ApplicationUser>, ICollection<ApplicationUserViewModel>>();
            Mapper.CreateMap<ICollection<ApplicationUserViewModel>, ICollection<ApplicationUser>>();

            Mapper.CreateMap<Ebook, EbookViewModel>();
            Mapper.CreateMap<EbookViewModel, Ebook>();

            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();

            Mapper.CreateMap<Payment, PaymentViewModel>();
            Mapper.CreateMap<PaymentViewModel, Payment>();

        }
    }
}