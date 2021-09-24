using System.Threading.Tasks;
using System;
using System.Linq;
using Xunit;
using DL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<Entity.CustomerDBContext> options;
        public DLTests{
            optinons = new DbContextOptionsBuilder<Entity.CustomerDBContext>()
            .UsesSqlite("Filename=Test.db").Options;
        Seed();
        }

        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using(CustomersDBContext context = new Entity.CustomersDBContext(options)){
                IRepo repo = new DBRepo(context);
                var customers = repo.GetAllCustomers();
                Assert.Equal(1, customers.Count);
            }
        }
        public void AddingACustomerShouldAddACustomer();

        private void Seed()
        {
            using(CustomersDBContext context = new Entity.CustomersDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.Addrange(
                    new Entity.Customers(){
                        Id = 1,
                        FirstName= "Mini",
                        LastName =  "Last",
                        Orders = new List<Entity.Orders>(){
                        Id = 1,
                        Order = 5,
                        }
                        
                    }
                );

                context.SaveChanges();
            }
        }
    }
}