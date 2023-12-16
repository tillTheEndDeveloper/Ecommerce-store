using ePhoneCourseWork.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Data.Services
{
	public interface IOrdersService
	{
		void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
		List<Order> GetOrdersByUserIdAndRole(string userId, string userRole);
	}

}
