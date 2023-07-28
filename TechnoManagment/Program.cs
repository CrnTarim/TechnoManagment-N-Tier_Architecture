using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBusinessLayer.Controller;
using TechnoDataBase.Context;
using TechnoDataBase.Interface;
using TechnoEntity.DTO;
using TechnoEntity.Entities;

namespace TechnoManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mapper = AutoMapperConfig.InitializeAutomapper();

            IRepository<User> userRepository = new Repository<User>();
            UserController userCon = new UserController(userRepository);

            List<User> users = new List<User>();

            IRepository<Product> productRepository = new Repository<Product>();
            ProductController proCon = new ProductController(productRepository);

            List<Product> Userproducts = new List<Product>();

            Console.WriteLine("WELCOME TO MANAGMENT PAGE! THIS PAGE OPENS AUTOMATICLY!\n");

            bool quit = false;

            while (!quit)
            {
                users = userCon.GetAllUsers();

                foreach (User userInfo in users)
                {
                    Console.WriteLine("\n"+userInfo.UserName + " " + userInfo.UserPhone + " " + userInfo.UserEmail +" "+ userInfo.UserID+ "\n");
                }

                Console.WriteLine("\n 1- Add User | 2- Update User | 3- Delete User | 4- Get All Users | 5- Quit \n");
                

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());              

                switch (choice)
                {
                    case 1:
                        
                        Console.WriteLine("Enter UserName: ");
                        string userName = Console.ReadLine();

                        Console.WriteLine("Enter UserPassword: ");
                        string userPassword = Console.ReadLine();

                        Console.WriteLine("Enter UserEmail: ");
                        string userEmail = Console.ReadLine();

                        Console.WriteLine("Enter UserPhone: ");
                        string userPhone = Console.ReadLine();

                        User userADD = new User
                        {
                            UserID = Guid.NewGuid(),
                            UserName = userName,
                            UserPassword = userPassword,
                            UserEmail = userEmail,
                            UserPhone = userPhone
                        };
                        int userAddedId;
                        try
                        {
                            userAddedId = userCon.AddUser(userADD);
                            if (userAddedId != -1)
                            {
                                Console.WriteLine("Product Added Successfully ");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add the product.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred while creating the product: " + ex.Message);

                        }
                        break;
                    case 2:
                       
                        Console.WriteLine("Enter User ID to update:");
                        string userIdToUpdateStr = Console.ReadLine();
                        Guid userIdToUpdate;

                        if (!Guid.TryParse(userIdToUpdateStr, out userIdToUpdate))
                        {
                            Console.WriteLine("Invalid input for user ID. Please enter a valid GUID.\n");
                            break;
                        }

                        User existingUser = users.FirstOrDefault(p => p.UserID == userIdToUpdate);

                        if (existingUser == null)
                        {
                            Console.WriteLine("User with the given ID was not found.\n");
                            break;
                        }

                        Console.WriteLine("Enter User Phone:");
                        string phoneUpdate = Console.ReadLine();
                        Console.WriteLine("Enter User email:");
                        string emailUpdate = Console.ReadLine();
                                             

                        User userUpdate = new User();
                        userUpdate.UserPhone = phoneUpdate;
                        userUpdate.UserEmail = emailUpdate;
                        userUpdate.UserName = existingUser.UserName;
                        userUpdate.UserID=userIdToUpdate;
                        userUpdate.UserPassword = existingUser.UserPassword;                      

                        try
                        {
                            int isUpdated = userCon.UpdateUser(userUpdate, userIdToUpdate);

                            if (isUpdated != -1)
                            {
                                Console.WriteLine("Updated Item");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update item.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                        }
                        
                        break;
                    case 3:
                        
                        Console.WriteLine("Deleting a User...");
                        Console.WriteLine("Enter ID to delete User");
                        string idToDeleteStr = Console.ReadLine();
                        Guid idToDelete;
                        if (Guid.TryParse(idToDeleteStr, out idToDelete))
                        {
                            try
                            {
                                int isDeleted = userCon.DeleteUser(idToDelete);

                                if (isDeleted != 0)
                                {
                                    Console.WriteLine("User Deleted Successfully.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Failed Delete.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for user ID. Please enter a valid GUID.");
                        }
                        break;
                    case 4:
                        
                        Console.WriteLine("Get All User...");
                        users = userCon.GetAllUsers();

                        foreach (User userInfo in users)
                        {
                            Console.WriteLine(userInfo.UserName + " " + userInfo.UserPhone + " " + userInfo.UserEmail + "\n");
                        }
                        break;
                    case 5:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Welcome to Managment Page Please Enter The System\n");
            Console.WriteLine("User List: \n");
            foreach (User userGet in users)
            {
                var userDTO = mapper.Map<UserDTO>(userGet);
                Console.WriteLine("UserName: " + userDTO.UserName);
                Console.WriteLine("UserPassword: " + userDTO.UserPassword);
                Console.WriteLine("--------------------------------------");
            }

            Console.WriteLine("Please enter UserName and Password to Open UserPage");
            Console.WriteLine("UserName:");
            string uname = Console.ReadLine();
            Console.WriteLine("Password:");
            string upass = Console.ReadLine();

            User userToFind = users.FirstOrDefault(u => u.UserName == uname && u.UserPassword == upass);

            if (userToFind == null)
            {
                Console.WriteLine("Error! UserName or Password is Missing.");
                return;
            }
            while (true)
            {
                Console.WriteLine("\n1- Add Product | 2- Delete Product | 3- Update Product | 4- Get All Products | 5- Quit");                              
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                       
                        Console.WriteLine("Product Name: ");
                        string productName = Console.ReadLine();

                        Console.WriteLine("Product Price: ");
                        decimal productPrice;
                        decimal.TryParse(Console.ReadLine(), out productPrice);

                        Console.WriteLine("Product Category: ");
                        string productCategory = Console.ReadLine();

                        Console.WriteLine("Product Firm: ");
                        string productFirm = Console.ReadLine();

                        Product product = new Product
                        {
                            ProductID = Guid.NewGuid(),
                            ProductName = productName,
                            ProductPrice = productPrice,
                            ProductCategory = productCategory,
                            ProductFirm = productFirm,
                            UserID = userToFind.UserID 
                        };

                        int addedProductId;
                        try
                        {
                            addedProductId = proCon.AddProduct(product);
                            if (addedProductId != -1)
                            {
                                Console.WriteLine("Product Added Successfully ");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add the product.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred while creating the product: " + ex.Message);
                        }
                        break;
                    case 2:
                        // Delete Product

                        Userproducts = proCon.FindProducts(p => p.UserID == userToFind.UserID);
                        foreach (Product p in Userproducts)
                        {
                            Console.WriteLine($"ProductID: {p.ProductID}");
                            Console.WriteLine($"ProductName: {p.ProductName}");
                            Console.WriteLine($"ProductCategory: {p.ProductCategory}");
                            Console.WriteLine($"ProductPrice: {p.ProductPrice}");
                            Console.WriteLine($"ProductFirm: {p.ProductFirm}");                           
                            Console.WriteLine("------------------------------");
                        }

                        Console.WriteLine("Deleting a product...");
                        Console.WriteLine("Enter ID to delete Product");

                        string idToDeleteStr = Console.ReadLine();
                        Guid idToDelete;
                        if (Guid.TryParse(idToDeleteStr, out idToDelete))
                        {
                            try
                            {
                                int isDeleted = proCon.DeleteProduct(idToDelete);

                                if (isDeleted != 0)
                                {
                                    Console.WriteLine("Product Deleted Successfully.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Failed Delete.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for product ID.");
                        }
                       
                        break;
                    case 3:

                        Userproducts = proCon.FindProducts(p => p.UserID == userToFind.UserID);
                        foreach (Product p in Userproducts)
                        {
                            Console.WriteLine($"ProductID: {p.ProductID}");
                            Console.WriteLine($"ProductName: {p.ProductName}");
                            Console.WriteLine($"ProductCategory: {p.ProductCategory}");
                            Console.WriteLine($"ProductPrice: {p.ProductPrice}");
                            Console.WriteLine($"ProductFirm: {p.ProductFirm}");
                            Console.WriteLine("------------------------------");
                        }
                        Console.WriteLine("Enter Product ID to update:");
                        string productIdToUpdateStr = Console.ReadLine();
                        Guid productIdToUpdate;

                        if (!Guid.TryParse(productIdToUpdateStr, out productIdToUpdate))
                        {
                            Console.WriteLine("Invalid input for product ID. Please enter a valid GUID.\n");
                            break;
                        }

                        Product existingProduct = Userproducts.FirstOrDefault(p => p.ProductID == productIdToUpdate);

                        if (existingProduct == null)
                        {
                            Console.WriteLine("Product with the given ID was not found.\n");
                            break;
                        }

                        Console.WriteLine("Enter Product Name:");
                        string nameUpdate = Console.ReadLine();
                        Console.WriteLine("Enter Product Category:");
                        string categoryUpdate = Console.ReadLine();
                        Console.WriteLine("Enter Product Firm:");
                        string firmUpdate = Console.ReadLine();
                        Console.WriteLine("Enter Product Price:");

                        int priceUpdate;
                        if (!int.TryParse(Console.ReadLine(), out priceUpdate))
                        {
                            Console.WriteLine("Invalid input for Product Price. Please enter a valid integer value.");
                            break;
                        }

                        Product pToUpdate = new Product();
                        pToUpdate.ProductID = productIdToUpdate;
                        pToUpdate.ProductName = nameUpdate;
                        pToUpdate.ProductCategory = categoryUpdate;
                        pToUpdate.ProductPrice = priceUpdate;
                        pToUpdate.ProductFirm=firmUpdate;

                        try
                        {
                            int isUpdated = proCon.UpdateProduct(pToUpdate, productIdToUpdate);

                            if (isUpdated != -1)
                            {
                                Console.WriteLine("Updated Item");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update item.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                        }
                        break;
                       
                    case 4:
                        Userproducts = proCon.FindProducts(p => p.UserID == userToFind.UserID);
                        foreach (Product p in Userproducts)
                        {
                            Console.WriteLine($"ProductID: {p.ProductID}");
                            Console.WriteLine($"ProductName: {p.ProductName}");
                            Console.WriteLine($"ProductCategory: {p.ProductCategory}");
                            Console.WriteLine($"ProductPrice: {p.ProductPrice}");
                            Console.WriteLine($"ProductFirm: {p.ProductFirm}");
                            Console.WriteLine("------------------------------");
                        }
                        break;
                    
                    case 5:
                        
                        Console.WriteLine("Quitting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }         

        }
    }
}
