﻿using Model.Entities;
using Repository.Base.GenericRepositoryInterface;

namespace Repository.RepositoryInterface
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    }
}
