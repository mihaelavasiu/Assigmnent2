using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1
{
    public interface IDBManager
    {
        void RegisterUser(User user);
        void Create(Product product);
        void Update(Product product);
        void UpdateOrder(Order order);
        void AddOrder(Order order);
        void ModifyOrder(Order order, int addPieces);
        void AddEmployee(Employee e);
        void UpdateEmployee(Employee e);
        void DeleteEmployee(Employee e);
        Product SelectProduct(Product p);

    }
}
