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
            Entity.Customer custoToAdd = new Entity.Customer(){
                FirstName = custo.FirstName,
                LastName = custo.LastName
                
            };
            
            
            custoToAdd = _context.Add(custoToAdd).Entity;

            
            _context.SaveChanges();

            
            _context.ChangeTracker.Clear();

            return new Model.Customers()
            {
                CustomerId = custoToAdd.Id,
                FirstName = custoToAdd.FirstName,
                LastName = custoToAdd.LastName,
                
            };
        }

        public List<Model.Customers> GetAllCustomers()
        {
            
            return _context.Customers.Select(
                customer => new Model.Customers() {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                }
            ).ToList();

            
        }

        public Model.Customers UpdateCustomers(Model.Customers customerToUpdate)
        {
            Entity.Customer customersToUpdate = new Entity.Customer() {
                Id = customerToUpdate.CustomerId,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName
                
            };

            customersToUpdate = _context.Customers.Update(customersToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customers() {
                CustomerId = customerToUpdate.CustomerId,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName
                
            };
        }

        public List<Model.Customers> SearchCustomers(string queryStr)
        {
            return _context.Customers.Where(
                custo => custo.FirstName.Contains(queryStr) || custo.LastName.Contains(queryStr) 
            ).Select(
                c => new Model.Customers(){
                    CustomerId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    
                }
            ).ToList();
        }

        public Model.Orders AddOrder(Model.Orders order)
        {
            Entity.Order orderToAdd = new Entity.Order(){
                CustomerId = order.CustomerId,
                

            };
            orderToAdd = _context.Orders.Add(orderToAdd).Entity;
            _context.SaveChanges();

            return new Model.Orders() {
                OrderId = orderToAdd.Id,
                CustomerId = orderToAdd.Id,
                
            };
        }

        
        public Model.Customers GetOneCustomerById(int id)
        {
            Entity.Customer custoById = 
                _context.Customers
                
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);

            return new Model.Customers() {
                CustomerId = custoById.Id,
                FirstName = custoById.FirstName,
                LastName = custoById.LastName,
                Orders = custoById.Orders.Select(c => new Model.Orders(){
                    OrderId = c.Id,
                    CustomerId = c.Id,
                    
                }).ToList()
            };
        }
    }
}