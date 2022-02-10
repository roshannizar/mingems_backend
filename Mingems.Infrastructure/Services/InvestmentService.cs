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
            #region Validate Email
            if (!string.IsNullOrEmpty(investment.Email))
            {
                var trueMail = false;
                List<string> checkEmail = new List<string>() { "outlook.com", "gmail.com", "yahoo.com", "hotmail.com" };

                var index = investment.Email.IndexOf("@");
                var removed = investment.Email.Substring(index + 1, investment.Email.Length - index - 1);

                foreach (var item in checkEmail)
                {
                    if (item == removed)
                    {
                        trueMail = true;
                    }
                }

                if (!trueMail)
                    throw new InvalidException("Invalid Email, Please try again with a valid mail");
            }
            #endregion

            await unitOfWork.InvestmentRepository.AddAsync(investment.Create(email, investment));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(Id);
            if (investment == null)
                throw new NotFoundException("Investment not found or already removed");
            var purchases = await unitOfWork.PurchaseRepository.GetAllAsync();
            var count = purchases.Where(p => p.InvestorId == investment.Id).ToList().Count;
            if (count <= 0)
                throw new InvalidException($"{investment.FirstName} is already connected with another record, please remove the connected records!");
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
