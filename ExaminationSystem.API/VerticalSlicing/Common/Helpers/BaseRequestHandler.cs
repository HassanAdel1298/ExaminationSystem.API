using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Data.BaseRepository;

namespace ExaminationSystem.API.VerticalSlicing.Common.Helpers
{
    public abstract class BaseRequestHandler<TEntity, TRequest, TResponse> : 
                        IRequestHandler<TRequest, TResponse> 
                        where TRequest : IRequest<TResponse> 
                        where TEntity : BaseModel
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseRequestHandler(RequestParameters<TEntity> requestParameters)
        {
            _mediator = requestParameters.Mediator;
            _userState = requestParameters.UserState;
            _repository = requestParameters.Repository;

        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
