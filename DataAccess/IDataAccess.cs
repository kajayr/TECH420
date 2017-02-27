using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IDataAccess
    {
        void LogOrder(OrderDetail pOrderDetail);
        List<OrderDetail> GetAllOrders();
        void ClearHistory();
    }
}