﻿using Mingems.Core.Repositories;
using Mingems.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MingemsDbContext context;
        private IUserRepository _userRepository;
        private ISupplierRepository _supplierRepository;
        private IInvestmentRepository _investmentRepository;
        private ICustomerRepository _customerRepository;
        private IPurchaseRepository _purchaseRepository;
        private ISubscriptionRepository _subscriptionRepository;
        private IPrivateCodeRepository _privateCodeRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(MingemsDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);
        public ISupplierRepository SupplierRepository => _supplierRepository ??= new SupplierRepository(context);
        public IInvestmentRepository InvestmentRepository => _investmentRepository ??= new InvestmentRepository(context);
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(context);
        public IPurchaseRepository PurchaseRepository => _purchaseRepository ??= new PurchaseRepository(context);
        public ISubscriptionRepository SubscriptionRepository => _subscriptionRepository ??= new SubscriptionRepository(context);
        public IPrivateCodeRepository PrivateCodeRepository => _privateCodeRepository ??= new PrivateCodeRepository(context);
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
