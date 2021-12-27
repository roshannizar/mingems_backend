using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using Mingems.Shared.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) {}

        public async Task CreateAsync(Customer model)
        {
            #region Validate Email
            var trueMail = false;
            List<string> checkEmail = new List<string>() { "outlook.com", "gmail.com", "yahoo.com", "hotmail.com" };

            var index = model.Email.IndexOf("@");
            var removed = model.Email.Substring(index + 1, model.Email.Length - index - 1);

            foreach (var item in checkEmail)
            {
                if (item == removed)
                {
                    trueMail = true;
                }
            }
            #endregion

            if (!trueMail)
                throw new InvalidException("Invalid Email, Please try again with a valid mail");
            await unitOfWork.CustomerRepository.AddAsync(model.Create(email, model));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var customer = await unitOfWork.CustomerRepository.GetByIdAsync(Id);
            if (customer == null)
                throw new NotFoundException("Customer not found or already removed");
            unitOfWork.CustomerRepository.Remove(customer.Delete(email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await unitOfWork.CustomerRepository.GetAllAsync();
        }

        public async Task<Customer> GetAsync(string Id)
        {
            return await unitOfWork.CustomerRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Customer model)
        {
            var customer = await unitOfWork.CustomerRepository.GetByIdAsync(model.Id);
            if (customer == null)
                throw new NotFoundException("Customer not found or already removed");
            unitOfWork.CustomerRepository.Update(customer.Update(email, model));
            await unitOfWork.CommitAsync();
        }
    }
}
