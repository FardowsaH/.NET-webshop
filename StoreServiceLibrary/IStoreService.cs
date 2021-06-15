using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StoreServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreService" in both code and config file together.
    [ServiceContract]
    public interface IStoreService
    {
        [OperationContract]
        string Register(String username);
        [OperationContract]
        bool Login(String username, String password);

        [OperationContract]
        IEnumerable<ProductPartial> GetProducts();

        [OperationContract]
        bool OrderProduct(string username, string productName, int quantity);

        [OperationContract]
        IEnumerable<Order> GetOrders(string username);

        [OperationContract]
        double GetBalance(string username);
    }
}
