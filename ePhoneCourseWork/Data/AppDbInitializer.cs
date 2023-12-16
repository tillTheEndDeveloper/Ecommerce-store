using ePhoneCourseWork.Data.Enums;
using ePhoneCourseWork.Data.Static;
using ePhoneCourseWork.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                //Products
                if (!context.Products.Any())
                {
                    try
                    {
                        context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "iPhone 13 Pro",
                            Image = "https://www.google.com/aclk?sa=l&ai=DChcSEwj6j4G8-Zr_AhVpDOYKHYl4AGgYABABGgJscg&sig=AOD64_3arF0XZdg_Y-USbvEWlT4Ylh-7bg&adurl&ctype=5&ved=2ahUKEwiU6PG7-Zr_AhVmCBAIHZ_XAjEQvhd6BAgBEEo",
                            Description = "The flagship iPhone with advanced features and powerful performance.",
                            Color = Color.Purple,
                            Price = 1099.99,
                        },
                        new Product()
                        {
                            Name = "iPhone 13",
                            Image = "https://hotline.ua/img/tx/298/2989120245.jpg",
                            Description = "The latest iPhone model with advanced features.",
                            Color = Color.Blue,
                            Price = 999.99,
                        },
                        new Product()
                        {
                            Name = "iPhone 12 Pro",
                            Image = "https://www.google.com/aclk?sa=l&ai=DChcSEwjz2bbc-Zr_AhUaLBgKHRDnDcYYABABGgJsZQ&sig=AOD64_0yHZFMhV2AXS86QHOnka4ANnQ-ag&adurl&ctype=5&ved=2ahUKEwjf8qzc-Zr_AhUQwioKHanrBuEQvhd6BAgBEEo",
                            Description = "Powerful and feature-packed iPhone.",
                            Color = Color.Blue,
                            Price = 899.99,
                        },
                        new Product()
                        {
                            Name = "iPhone 12",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9dLym8tzERWWaD7y_IQB2K5OqdVgoru5Gmw&usqp=CAU",
                            Description = "A versatile iPhone with great performance.",
                            Color = Color.Yellow,
                            Price = 799.99,
                        },
                        new Product()
                        {
                            Name = "iPhone SE",
                            Image = "https://www.google.com/aclk?sa=l&ai=DChcSEwiK2OK0hJv_AhXQBaIDHYtiDGoYABABGgJsZQ&sig=AOD64_3vj4ToNFFu91C6moqIJO_DxvfewA&adurl&ctype=5&ved=2ahUKEwicltm0hJv_AhUPwyoKHT55DcoQvhd6BAgBEFM",
                            Description = "Compact and affordable iPhone.",
                            Color = Color.Red,
                            Price = 399.99,
                        },
                        new Product()
                        {
                            Name = "iPhone 11 Pro",
                            Image = "https://www.google.com/aclk?sa=l&ai=DChcSEwjq8a3FhJv_AhVE7lEKHQAXC1QYABABGgJ3cw&sig=AOD64_1suCmqya17iSTYWm8qiJQxYEU6Ig&adurl&ctype=5&ved=2ahUKEwim2KDFhJv_AhXCvioKHbzzCjQQvhd6BAgBEE0",
                            Description = "The previous-generation flagship iPhone with exceptional features.",
                            Color = Color.Green,
                            Price = 999.99,
                        },
                        new Product()
                        {
                            Name = "iPhone 11",
                            Image = "https://www.google.com/aclk?sa=l&ai=DChcSEwjMh83zhJv_AhUJBaIDHb6nAGEYABADGgJsZQ&sig=AOD64_2q66ZcAMluNiqh_uktMzGLmX5-HA&adurl&ctype=5&ved=2ahUKEwjt48LzhJv_AhURxioKHaybATIQvhd6BAgBEFE",
                            Description = "Previous-generation iPhone with great performance.",
                            Color = Color.Black,
                            Price = 699.99,
                        },
                        new Product()
                        {
                            Name = "iPhone XR",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSahZzpmJv8WfhyRCz6wqZRRQP77gU1SlE-bw&usqp=CAU",
                            Description = "Colorful and budget-friendly iPhone.",
                            Color = Color.Yellow,
                            Price = 599.99,
                        },
                        new Product()
                        {
                            Name = "iPhone 8 Plus",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNtihzdxCl9bt83os_3sELkszq8WJB_B7UoA&usqp=CAU",
                            Description = "Large-screen iPhone with a classic design.",
                            Color = Color.Red,
                            Price = 699.99,
                        },
                    });
                        context.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        var innerException = ex.InnerException;
                        while (innerException != null)
                        {
                            Console.WriteLine(innerException.Message);
                            innerException = innerException.InnerException;
                        }
                    }
                }
            }
        }

        public static async Task SeedUsersAndRolsAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.BlackListed))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.BlackListed));
                }

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@ephone.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);

                }


                string appUserEmail = "user@ephone.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Appication User",
                        UserName = "app-user",
                        DateOfBirth = new DateTime(2000, 1, 1),
                        PhoneNumber = "0660261275",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
