﻿using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnuitexTraining.DataAccessLayer.Initialization
{
    public class DataBaseInitialization
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            Author[] authors = new Author[]
            {
                new Author() { Id = 1, CreationDate = DateTime.Now, Name = "Jmih V.A." },
                new Author() { Id = 2, CreationDate = DateTime.Now, Name = "Drozdov G.L." },
                new Author() { Id = 3, CreationDate = DateTime.Now, Name = "Teodorov V.V." },
                new Author() { Id = 4, CreationDate = DateTime.Now, Name = "Kovalenko S.A." },
                new Author() { Id = 5, CreationDate = DateTime.Now, Name = "Gorin O.V." }
            };

            PrintingEdition[] printingEditions = new PrintingEdition[]
            {
                new PrintingEdition() { Id = 1, CreationDate = DateTime.Now, Currency = Currency.UAH, Description = "Neurotechnologies", Price = 1000 },
                new PrintingEdition() { Id = 2, CreationDate = DateTime.Now, Currency = Currency.EUR, Description = "C# Starter", Price = 20 },
                new PrintingEdition() { Id = 3, CreationDate = DateTime.Now, Currency = Currency.USD, Description = "ASP.NET MVC 5", Price = 100 },
                new PrintingEdition() { Id = 4, CreationDate = DateTime.Now, Currency = Currency.EUR, Description = "How it works", Price = 50 },
                new PrintingEdition() { Id = 5, CreationDate = DateTime.Now, Currency = Currency.USD, Description = "Angular 9", Price = 70 }
            };

            AuthorInPrintingEdition[] authorInPrintingEditions = new AuthorInPrintingEdition[]
            {
                new AuthorInPrintingEdition() { AuthorId = 1, PrintingEditionId = 1, Date = new DateTime(2008,4,12)},
                new AuthorInPrintingEdition() { AuthorId = 2, PrintingEditionId = 2, Date = new DateTime(2010,1,6)},
                new AuthorInPrintingEdition() { AuthorId = 3, PrintingEditionId = 3, Date = new DateTime(2016,7,13)},
                new AuthorInPrintingEdition() { AuthorId = 4, PrintingEditionId = 4, Date = new DateTime(2002,5,5)},
                new AuthorInPrintingEdition() { AuthorId = 5, PrintingEditionId = 5, Date = new DateTime(2020,4,25)}
            };

            Payment[] payments = new Payment[]
            {
                new Payment() { Id = 1, CreationDate = DateTime.Now, TransactionId = 21847238958},
                new Payment() { Id = 2, CreationDate = DateTime.Now, TransactionId = 57976548678}
            };

            ApplicationUser[] applicationUsers = new ApplicationUser[]
            {
                new ApplicationUser() { Id = 1, Email = "admin@example.com", FirstName = "Vladislav", LastName = "Goncharuk", UserName = "vladiator", PhoneNumber = "+380935538212", EmailConfirmed = true, PhoneNumberConfirmed = true},
                new ApplicationUser() { Id = 2, Email = "user@example.com", FirstName = "Valerij", LastName = "Jmishenko", UserName = "valerajmih", PhoneNumber = "+380503487621", EmailConfirmed = true, PhoneNumberConfirmed = true }
            };

            IdentityRole<long>[] identityRoles = new IdentityRole<long>[]
            {
                new IdentityRole<long>() { Id = 1, Name = "Admin"},
                new IdentityRole<long>() { Id = 2, Name = "User"}
            };

            IdentityUserRole<long>[] identityUserRoles = new IdentityUserRole<long>[]
            {
                new IdentityUserRole<long>() { RoleId = 1, UserId = 1},
                new IdentityUserRole<long>() { RoleId = 2, UserId = 2}
            };

            Order[] orders = new Order[]
            {
                new Order() { Id = 1, UserId = 2, CreationDate = DateTime.Now, Date = DateTime.Now, PaymentId = 1, Description = "Nothing special", Status = OrderStatus.Paid},
                new Order() { Id = 2, UserId = 2, CreationDate = DateTime.Now, Date = DateTime.Now, PaymentId = 2, Description = "And here is nothing special", Status = OrderStatus.Unpaid}
            };

            OrderItem[] orderItems = new OrderItem[]
            {
                new OrderItem() { Id = 1, CreationDate = DateTime.Now, Amount = 2, OrderId = 1, PrintingEditionId = 1, Count = printingEditions[0].Price * 2, Currency = printingEditions[0].Currency},
                new OrderItem() { Id = 2, CreationDate = DateTime.Now, Amount = 7, OrderId = 2, PrintingEditionId = 1, Count = printingEditions[0].Price * 7, Currency = printingEditions[0].Currency },
                new OrderItem() { Id = 3, CreationDate = DateTime.Now, Amount = 4, OrderId = 1, PrintingEditionId = 2, Count = printingEditions[1].Price * 4, Currency = printingEditions[1].Currency },
                new OrderItem() { Id = 4, CreationDate = DateTime.Now, Amount = 10, OrderId = 1, PrintingEditionId = 4, Count = printingEditions[3].Price * 10, Currency = printingEditions[3].Currency },
                new OrderItem() { Id = 5, CreationDate = DateTime.Now, Amount = 6, OrderId = 1, PrintingEditionId = 5, Count = printingEditions[4].Price * 6, Currency = printingEditions[4].Currency }
            };

            modelBuilder.Entity<Author>().HasData(authors);

            modelBuilder.Entity<PrintingEdition>().HasData(printingEditions);

            modelBuilder.Entity<AuthorInPrintingEdition>().HasData(authorInPrintingEditions);

            modelBuilder.Entity<Payment>().HasData(payments);

            modelBuilder.Entity<ApplicationUser>().HasData(applicationUsers);

            modelBuilder.Entity<IdentityRole<long>>().HasData(identityRoles);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(identityUserRoles);

            modelBuilder.Entity<Order>().HasData(orders);

            modelBuilder.Entity<OrderItem>().HasData(orderItems);
        }
    }
}