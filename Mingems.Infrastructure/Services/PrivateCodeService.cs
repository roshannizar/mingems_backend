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
    public class PrivateCodeService : BaseService, IPrivateCodeService
    {
        public PrivateCodeService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task CreateAsync(PrivateCode model)
        {
            await unitOfWork.PrivateCodeRepository.AddAsync(model.Create(email, model));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var privateCode = await unitOfWork.PrivateCodeRepository.GetByIdAsync(Id);
            if (privateCode == null)
                throw new NotFoundException("Private Code not found!");
            unitOfWork.PrivateCodeRepository.Remove(privateCode.Delete(email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PrivateCode>> GetAllAsync()
        {
            return await unitOfWork.PrivateCodeRepository.GetAllAsync();
        }

        public async Task<PrivateCode> GetAsync(string Id)
        {
            return await unitOfWork.PrivateCodeRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(PrivateCode model)
        {
            var privateCode = await unitOfWork.PrivateCodeRepository.GetByIdAsync(model.Id);
            if (privateCode == null)
                throw new NotFoundException("Private Code not found!");
            unitOfWork.PrivateCodeRepository.Update(privateCode.Update(email, model));
            await unitOfWork.CommitAsync();
        }
    }
}
