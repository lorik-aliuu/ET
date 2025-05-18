using AutoMapper;
using ET.Application.Views;
using ET.Domain.Entities;

namespace ET.API.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap<User, UserDTO>();

            CreateMap<UserRegistrationDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateUserDTO, User>()
    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();

            CreateMap<Expense, ExpenseDTO>();

           
            CreateMap<CreateExpenseDTO, Expense>();

           
            CreateMap<UpdateExpenseDTO, Expense>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<CategoryBudget, CategoryBudgetDTO>();

            CreateMap<CreateCategoryBudgetDTO, CategoryBudget>();

            CreateMap<UpdateCategoryBudgetDTO, CategoryBudget>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
    
}
