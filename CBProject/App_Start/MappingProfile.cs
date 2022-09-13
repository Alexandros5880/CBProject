using AutoMapper;
using CBProject.Areas.Forum.Models.ViewModels;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;

namespace CBProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationRole, IdentityRoleViewModel>();
            Mapper.CreateMap<IdentityRoleViewModel, ApplicationRole>();

            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();

            Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>();
            Mapper.CreateMap<ApplicationUserViewModel, ApplicationUser>();

            Mapper.CreateMap<ApplicationUser, ApplicationUserForumViewModel>();
            Mapper.CreateMap<ApplicationUserForumViewModel, ApplicationUser>();

            Mapper.CreateMap<Ebook, EbookViewModel>();
            Mapper.CreateMap<EbookViewModel, Ebook>();

            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();

            Mapper.CreateMap<Payment, PaymentViewModel>();
            Mapper.CreateMap<PaymentViewModel, Payment>();

            Mapper.CreateMap<SubscriptionPackage, SubscriptionPackageViewModel>();
            Mapper.CreateMap<SubscriptionPackageViewModel, SubscriptionPackage>();

            Mapper.CreateMap<Rating, RatingViewModel>();
            Mapper.CreateMap<RatingViewModel, Rating>();

            Mapper.CreateMap<Review, ReviewViewModel>();
            Mapper.CreateMap<ReviewViewModel, Review>();

            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<TagViewModel, Tag>();

            Mapper.CreateMap<Video, VideoViewModel>();
            Mapper.CreateMap<VideoViewModel, Video>();

            Mapper.CreateMap<EmployeeRequest, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, EmployeeRequest>();
        }
    }
}