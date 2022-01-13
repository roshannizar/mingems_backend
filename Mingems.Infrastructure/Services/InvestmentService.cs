using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using Mingems.Shared.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class InvestmentService : BaseService, IInvestmentService
    {
        public InvestmentService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task CreateAsync(Investment investment)
        {
            await unitOfWork.InvestmentRepository.AddAsync(investment.Create(email, investment));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(Id);
            if (investment == null)
                throw new NotFoundException("Investment not found or already removed");
            unitOfWork.InvestmentRepository.Remove(investment.Delete(email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Investment>> GetAllAsync()
        {
            return await unitOfWork.InvestmentRepository.GetAllAsync();
        }

        public async Task<Investment> GetAsync(string Id)
        {
            return await unitOfWork.InvestmentRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Investment>> GetUniqueInvestors()
        {
            var query = await unitOfWork.InvestmentRepository.GetAllAsync();
            return query.Where(i => i.Origin == true).ToList();
        }

        public async Task UpdateAsync(Investment model)
        {
            var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(model.Id);
            if (investment == null)
                throw new NotFoundException("Investment not found or already removed");
            unitOfWork.InvestmentRepository.Update(investment.Update(email, model));
            await unitOfWork.CommitAsync();
        }
    }
}
