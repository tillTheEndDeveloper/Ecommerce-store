using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePhoneCourseWork.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int quantity { get; set; }
		public int Amount { get; set; }
		public double Price { get; set; }

		//Relationships

		//Product
		public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        //Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
