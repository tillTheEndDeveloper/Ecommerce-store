using ePhoneCourseWork.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePhoneCourseWork.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Status Status { get; set; }
        public double TotalPrice { get; set; }
		public string Email { get; set; }
		public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public ApplicationUser User { get; set; }

		//Relationships
		public List<OrderItem> OrderItems { get; set; }

    }
}
