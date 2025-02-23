using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Data.BaseRepository;
using ExaminationSystem.API.VerticalSlicing.Data.Models;

namespace ExaminationSystem.API.VerticalSlicing.Common
{
    public class RequestParameters<T> where T : BaseModel
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }
        public IBaseRepository<T> Repository { get; set; }

        public RequestParameters(IMediator mediator,
            UserState userState,
            IBaseRepository<T> repository)
        {
            Mediator = mediator;
            UserState = userState;
            Repository = repository;
        }
    }
}
