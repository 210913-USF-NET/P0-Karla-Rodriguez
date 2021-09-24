using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.P0DBContext _context;
        public DBRepo(Entity.P0DBContext context)
        {
            _context = context;
        }
        //private void Seed()
            //{
                //using(Entity.P0DBContext context = new Entity.P0DBContext())
            //}
        
        public Model.Customers AddCustomers(Model.Customers custo)
        {
            Entity.Customer restoToAdd = new Entity.Customer(){
                FirstName = custo.FirstName,
                LastName = custo.Lastname
                
            };
            
            
            custoToAdd = _context.Add(custoToAdd).Entity;

            
            _context.SaveChanges();

            
            _context.ChangeTracker.Clear();

            return new Model.Customers()
            {
                Id = custoToAdd.Id,
                FirstName = restoToAdd.FirstName,
                LastName = restoToAdd.LastName,
                
            };
        }

        public List<Model.Customers> GetAllCustomers()
        {
            
            return _context.Customers.Select(
                customer => new Model.Customers() {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                }
            ).ToList();

            
        }

        public Model.Customers UpdateCustomers(Model.Customers customerToUpdate)
        {
            Entity.Customer customerToUpdate = new Entity.Customer() {
                Id = customerToUpdate.Id,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName
                
            };

            customerToUpdate = _context.Customers.Update(customerToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customers() {
                Id = customerToUpdate.Id,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName
                
            };
        }

        public List<Model.Customers> SearchCustomers(string queryStr)
        {
            return _context.Customer.Where(
                custo => custo.FirstName.Contains(queryStr) || custo.LastName.Contains(queryStr) 
            ).Select(
                c => new Model.Customers(){
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    
                }
            ).ToList();
        }

        public Model.Orders AddOrder(Model.Orders order)
        {
            Entity.Orders orderToAdd = new Entity.Orders(){
                CustomerId = order.CustomerId,
                VendorId = order.VendorId,
                RestaurantId = order.RestaurantId
            };
            orderToAdd = _context.Orders.Add(orderToAdd).Entity;
            _context.SaveChanges();

            return new Model.Orders() {
                Id = orderToAdd.Id,
                CustomerId = orderToAdd.CustomerId,
                VendorId = orderToAdd.VendorId
            };
        }

        
        public Model.Customers GetOneCustomerById(int id)
        {
            Entity.Customer custoById = 
                _context.Customer
                
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);

            return new Model.Customers() {
                Id = custoById.Id,
                FirstName = custoById.FirstName,
                LastName = custoById.LastName,
                Orders = custoById.Orders.Select(c => new Model.Orders(){
                    Id = c.Id,
                    CustomerId = c.CustomerId,
                    VendorId = c.VendorId
                }).ToList()
            };
        }
    }
}