﻿using System;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Initialization
{
    public class DataBaseInitialization
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var authors = new[]
            {
                new Author {Id = 1, CreationDate = DateTime.UtcNow, Name = "Jmih V.A."},
                new Author {Id = 2, CreationDate = DateTime.UtcNow, Name = "Drozdov G.L."},
                new Author {Id = 3, CreationDate = DateTime.UtcNow, Name = "Teodorov V.V."},
                new Author {Id = 4, CreationDate = DateTime.UtcNow, Name = "Kovalenko S.A."},
                new Author {Id = 5, CreationDate = DateTime.UtcNow, Name = "Gorin O.V."}
            };

            var printingEditions = new[]
            {
                new PrintingEdition
                {
                    Id = 1, CreationDate = DateTime.UtcNow, Currency = CurrencyType.USD, Title = "Neurotechnologies",
                    Description = "Neurotechnologies", Price = 1000, Type = PrintingEditionType.Newspaper
                },
                new PrintingEdition
                {
                    Id = 2, CreationDate = DateTime.UtcNow, Currency = CurrencyType.USD, Title = "C# Starter",
                    Description = "C# Starter", Price = 20, Type = PrintingEditionType.Book
                },
                new PrintingEdition
                {
                    Id = 3, CreationDate = DateTime.UtcNow, Currency = CurrencyType.USD, Title = "ASP.NET MVC 5",
                    Description = "ASP.NET MVC 5", Price = 100, Type = PrintingEditionType.Book
                },
                new PrintingEdition
                {
                    Id = 4, CreationDate = DateTime.UtcNow, Currency = CurrencyType.USD, Title = "How it works",
                    Description = "How it works", Price = 50, Type = PrintingEditionType.Magazine
                },
                new PrintingEdition
                {
                    Id = 5, CreationDate = DateTime.UtcNow, Currency = CurrencyType.USD, Title = "Angular 9",
                    Description = "Angular 9", Price = 70, Type = PrintingEditionType.Book
                }
            };

            var authorInPrintingEditions = new[]
            {
                new AuthorInPrintingEdition {AuthorId = 1, PrintingEditionId = 1, Date = new DateTime(2008, 4, 12)},
                new AuthorInPrintingEdition {AuthorId = 2, PrintingEditionId = 2, Date = new DateTime(2010, 1, 6)},
                new AuthorInPrintingEdition {AuthorId = 3, PrintingEditionId = 3, Date = new DateTime(2016, 7, 13)},
                new AuthorInPrintingEdition {AuthorId = 4, PrintingEditionId = 4, Date = new DateTime(2002, 5, 5)},
                new AuthorInPrintingEdition {AuthorId = 5, PrintingEditionId = 5, Date = new DateTime(2020, 4, 25)}
            };

            var payments = new[]
            {
                new Payment {Id = 1, CreationDate = DateTime.UtcNow, TransactionId = "21847238958"},
                new Payment {Id = 2, CreationDate = DateTime.UtcNow, TransactionId = ""}
            };

            var applicationUsers = new[]
            {
                new ApplicationUser
                {
                    Id = 1, Email = "vladiator@xitroo.com", NormalizedEmail = "VLADIATOR@XITROO.COM",
                    FirstName = "Vladislav", LastName = "Goncharuk", UserName = "vladiator",
                    NormalizedUserName = "VLADIATOR", EmailConfirmed = true,
                    SecurityStamp = "UD6OIMX72OWACSZNP6QXRDB6AK5UAQWK",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEKHk3sTABbsMTgCaH81KcsHXbNSfveaBeQYBbLM8tOS5EKut5YWZcDbh7uCXUARPmQ==",
                    CreationDate = DateTime.UtcNow, PhoneNumber = ""
                },
                new ApplicationUser
                {
                    Id = 2, Email = "valera@xitroo.com", NormalizedEmail = "VALERA@XITROO.COM", FirstName = "Valerij",
                    LastName = "Jmishenko", UserName = "valerajmih", NormalizedUserName = "VALERAJMIH",
                    EmailConfirmed = true, SecurityStamp = "P5IWCILRLNALOGOW77G2WLTUREFC7BZG",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAELXM6ETOnIrNLqiksYqOZZ1tKbsO/TLM1hKXn9FCvapFZEcWYLcYxvK9rxxxDSQCSA==",
                    CreationDate = DateTime.UtcNow, PhoneNumber = ""
                }
            };

            var identityRoles = new[]
            {
                new IdentityRole<long> {Id = 1, Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole<long> {Id = 2, Name = "Client", NormalizedName = "CLIENT"}
            };

            var identityUserRoles = new[]
            {
                new IdentityUserRole<long> {RoleId = 1, UserId = 1},
                new IdentityUserRole<long> {RoleId = 2, UserId = 2}
            };

            var orders = new[]
            {
                new Order
                {
                    Id = 1, UserId = 2, CreationDate = DateTime.UtcNow, Date = DateTime.UtcNow, PaymentId = 1,
                    Description = "Nothing special", Status = OrderStatus.Paid
                },
                new Order
                {
                    Id = 2, UserId = 2, CreationDate = DateTime.UtcNow, Date = DateTime.UtcNow, PaymentId = 2,
                    Description = "And here is nothing special", Status = OrderStatus.Unpaid
                }
            };

            var orderItems = new[]
            {
                new OrderItem
                {
                    Id = 1, CreationDate = DateTime.UtcNow, Amount = printingEditions[0].Price * 2, OrderId = 1,
                    PrintingEditionId = 1, Count = 2, Currency = printingEditions[0].Currency
                },
                new OrderItem
                {
                    Id = 2, CreationDate = DateTime.UtcNow, Amount = printingEditions[0].Price * 7, OrderId = 2,
                    PrintingEditionId = 1, Count = 7, Currency = printingEditions[0].Currency
                },
                new OrderItem
                {
                    Id = 3, CreationDate = DateTime.UtcNow, Amount = printingEditions[1].Price * 4, OrderId = 1,
                    PrintingEditionId = 2, Count = 4, Currency = printingEditions[1].Currency
                },
                new OrderItem
                {
                    Id = 4, CreationDate = DateTime.UtcNow, Amount = printingEditions[3].Price * 10, OrderId = 1,
                    PrintingEditionId = 4, Count = 10, Currency = printingEditions[3].Currency
                },
                new OrderItem
                {
                    Id = 5, CreationDate = DateTime.UtcNow, Amount = printingEditions[4].Price * 6, OrderId = 1,
                    PrintingEditionId = 5, Count = 6, Currency = printingEditions[4].Currency
                }
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