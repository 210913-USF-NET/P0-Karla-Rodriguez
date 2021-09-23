using System;
using System.Collections.Generic;
using Models;

namespace P0BL
{
    public interface IBL
    {
        List<Customers> GetAllCustomers();

        Customers AddCustomers(Customers custo);

        Customers UpdateCustomers(Customers customerToUpdate);

        List<Customers> SearchCustomers(string quertStr);

        Orders AddOrder(Orders orders);

        Customers GetOneCustomerById(int id);
    }
}
