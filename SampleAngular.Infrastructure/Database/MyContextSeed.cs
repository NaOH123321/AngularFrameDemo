using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SampleAngular.Core.Entities;

namespace SampleAngular.Infrastructure.Database
{
    public class MyContextSeed
    {
        public static async Task SeedAsync(MyContext myContext,
                          ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                // TODO: Only run this if using a real database
                // myContext.Database.Migrate();
                if (!myContext.Categories.Any())
                {
                    myContext.Categories.AddRange(
                        new List<Category>{
                            new Category{
                                Id = 1,
                                Name = "IT",
                                CreateTime = DateTime.Now
                            },
                            new Category{
                                Id = 2,
                                Name = "互联网",
                                CreateTime = DateTime.Now
                            },
                            new Category{
                                Id = 3,
                                Name = "金融",
                                CreateTime = DateTime.Now
                            }
                        }
                    );
                    await myContext.SaveChangesAsync();
                }

                if (!myContext.Stocks.Any())
                {
                    myContext.Stocks.AddRange(
                        new List<Stock>{
                            new Stock{
                                Id = 1,
                                Name = "第一个股票",
                                Price = 1.99m,
                                Rating = 3.5m,
                                Desc = "这是第一个股票",
                                LastModified = null,
                                CreateTime = DateTime.Now,
                                StockCategories = new List<StockCategory>()
                                {
                                    new StockCategory(){StockId = 1, CategoryId = 2},
                                    new StockCategory(){StockId = 1, CategoryId = 3}
                                }
                            },
                            new Stock{
                                Id = 2,
                                Name = "第二个股票",
                                Price = 5.34m,
                                Rating = 1.0m,
                                Desc = "这是第二个股票",
                                LastModified = null,
                                CreateTime = DateTime.Now,
                                StockCategories = new List<StockCategory>()
                                {
                                    new StockCategory(){StockId = 2, CategoryId = 3}
                                }
                            }
                        }
                    );
                    await myContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(myContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
