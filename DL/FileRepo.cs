using System.Collections.Generic;
using Models;
using System.Text.Json;
using System;
using System.IO;
using System.Linq;
using Serilog;


namespace DL
{
    public class FileRepo : IRepo
    {
        private const string filepath = "../DL/Customers.json";
        
        private string jsonString;

        public Customers AddCustomer(Customers custo)
        {
            List<Customers> allCusto = GetAllCustomers();

            allCusto.Add(custo);
            jsonString = JsonSerializer.Serialize(allcusto);

            File.WriteAllText(filepath,jsonString);

            return custo;
        }
        public List<Customers> GetAllCustomers()
        {
            jsonString = filepath.ReadAllText(filepath);
            return JsonSerializer.Deserialize<List<Customers>>(jsonString);
        }

        public Customers UpdateCustomers(Customers customerToUpdate)
        {
            List<Customers> allCustomers = GetAllCustomers();
            int customerIndex = allCustomers.FindIndex(r => r.Equals(restaurantToUpdate));

            allCustomers[customerIndex] = customerToUpdate;

            jsonString = JsonSerializer.Serialize(allCustomers);

            File.WriteAllText(filepath, jsonString);

            return customerToUpdate;
        }
        
        }
    }