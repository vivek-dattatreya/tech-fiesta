using MicroRabbit.Banking.Data.DBContext;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public BankingDBContext _ctx;

        public AccountRepository(BankingDBContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }
    }
}
