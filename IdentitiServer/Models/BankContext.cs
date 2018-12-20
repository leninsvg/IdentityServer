using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClient.Models
{
	public class BankContext: DbContext
	{
		public BankContext(DbContextOptions<BankContext> options) : base(options)
		{

		}
		public DbSet<Customer> Customer { get; set; }
	}
}
