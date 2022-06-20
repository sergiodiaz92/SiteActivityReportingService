using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteActivityReportingService.Application.Common.Interfaces;
using SiteActivityReportingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityHandler : IRequestHandler<CreateActivityCommand, int>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateActivityHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            DateTime dateAndTime12hoursAgo = DateTime.Now.AddHours(-12);
            var entity = _mapper.Map<Activity>(request);
            var listEntities = await _dataContext.Activities.Where(ac => ac.key == request.key && ac.CreatedDate < dateAndTime12hoursAgo).ToListAsync();
            _dataContext.Activities.RemoveRange(listEntities);
            await _dataContext.Activities.AddAsync(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return entity.id;
        }
    }
}
