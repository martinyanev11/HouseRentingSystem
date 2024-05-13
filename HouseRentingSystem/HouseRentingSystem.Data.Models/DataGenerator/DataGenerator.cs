﻿namespace HouseRentingSystem.Data.Models.DataGenerator
{
    using Microsoft.AspNetCore.Identity;

    using static Constants.EntityConstants;

    public class DataGenerator
    {
        public static IEnumerable<IdentityUser> SeedUsers()
        {
            IEnumerable<IdentityUser> users = new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    Id = "dea12856-c198-4129-b3f3-b893d8395082",
                    UserName = "agent@mail.com",
                    NormalizedUserName = "AGENT@MAIL.COM",
                    Email = "agent@mail.com",
                    NormalizedEmail = "AGENT@MAIL.COM"
                },
                new IdentityUser()
                {
                    Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                    UserName = "guest@mail.com",
                    NormalizedUserName = "GUEST@MAIL.COM",
                    Email = "guest@mail.com",
                    NormalizedEmail = "GUEST@MAIL.COM"
                }
            };

            var hasher = new PasswordHasher<IdentityUser>();
            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, DefaultPassword);
            }

            return users;
        }

        public static IEnumerable<Agent> SeedAgents()
        {
            var agents = new List<Agent>()
            {
                new Agent()
                {
                    Id = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                    PhoneNumber = "+359888888888",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                },
            };

            return agents;
        }

        public static IEnumerable<Category> SeedCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cottage"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Single-Family"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Duplex"
                },
            };

            return categories;
        }

        public static IEnumerable<House> SeedHouse()
        {
            var houses = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Title = "Big House Marina",
                    Address = "North London, UK (near the border)",
                    Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                    ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                    PricePerMonth = 2100.00M,
                    CategoryId = 3,
                    AgentId = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                    RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                },
                new House()
                {
                    Id = 2,
                    Title = "Family House Comfort",
                    Address = "Near the Sea Garden in Burgas, Bulgaria",
                    Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                    PricePerMonth = 1200.00M,
                    CategoryId = 2,
                    AgentId = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                },
                new House()
                {
                    Id = 3,
                    Title = "Grand House",
                    Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                    Description = "This luxurious house is everything you will need. It is just excellent.",
                    ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                    PricePerMonth = 2000.00M,
                    CategoryId = 2,
                    AgentId = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                }
            };

            return houses;
        }
    }
}
