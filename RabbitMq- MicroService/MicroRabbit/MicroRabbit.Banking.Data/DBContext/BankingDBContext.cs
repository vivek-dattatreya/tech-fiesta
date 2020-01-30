using MicroRabbit.Banking.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Data.DBContext
{
    public class BankingDBContext : DbContext
    {
        public BankingDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
