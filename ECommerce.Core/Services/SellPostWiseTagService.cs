

using AutoMapper;
using ECommerce.Core.Interfaces;
using ECommerce.Domain.UnitOfWork;

namespace ECommerce.Core.Services
{
    public class SellPostWiseTagService : ISellPostWiseTagService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public SellPostWiseTagService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
