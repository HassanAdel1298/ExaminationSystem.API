using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;

namespace ExaminationSystem.API.VerticalSlicing.Common
{
    public class ControllereParameters
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }

        public ControllereParameters(IMediator mediator, UserState userState)
        {
            Mediator = mediator;
            UserState = userState;
        }
    }
}
