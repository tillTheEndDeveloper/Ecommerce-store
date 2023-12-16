using ePhoneCourseWork.Data.Base;
using ePhoneCourseWork.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ePhoneCourseWork.Models
{
    public class Product: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must by from 3 to 50")]
        public string Name { get; set; }
        [Display(Name = "Product Picture")]
        [Required(ErrorMessage = "Picture is required")]
        public string Image { get; set; }
        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Product Color")]
        [Required(ErrorMessage = "Color is required")]
        public Color Color { get; set; }
        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        //Reletionships
        public List<OrderItem> OrderItems { get; set; }
    }
}
