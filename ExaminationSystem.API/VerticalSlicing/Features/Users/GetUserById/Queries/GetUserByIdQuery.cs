using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Features.Users.Register;
using Azure;


namespace ExaminationSystem.API.VerticalSlicing.Features.Users.GetUserById.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<ResultDTO>;
    public class GetUserByIdQueryHandler : BaseRequestHandler<User, GetUserByIdQuery, ResultDTO>
    {
        public GetUserByIdQueryHandler(RequestParameters<User> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultDTO.Failure("Invalid UserID!");
            
            var user = await _repository.FirstOrDefaultAsync(u => u.Deleted == false && u.Id == request.id);

            if (user == null)
                return ResultDTO.Failure("No Data Found");

            var mappedUser = user.MapOne<UserRegisterDTO>();
            return ResultDTO.Success(mappedUser, "User has been retrieved successfully!");
        }
    }
}
