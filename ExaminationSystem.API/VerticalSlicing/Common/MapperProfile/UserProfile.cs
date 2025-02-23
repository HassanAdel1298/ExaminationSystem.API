using AutoMapper;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Features.Users.Login;
using ExaminationSystem.API.VerticalSlicing.Features.Users.Register;
using ExaminationSystem.API.VerticalSlicing.Features.Users.VerifyAccount;
using ExaminationSystem.API.VerticalSlicing.Features.Users.VerifyAccount.Commands;
using ExaminationSystem.VerticalSlicing.Features.Users.Login.Commands;
using ExaminationSystem.VerticalSlicing.Features.Users.Register;
using ExaminationSystem.VerticalSlicing.Features.Users.Register.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Common.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserForTokenDTO>().ReverseMap();

            CreateMap<UserRegisterRequest, RegisterUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();

            CreateMap<UserLoginRequest, LoginUserCommand>().ReverseMap();

            CreateMap<VerifyAccountRequest, VerifyAccountCommand>().ReverseMap();
        }
    }
}
