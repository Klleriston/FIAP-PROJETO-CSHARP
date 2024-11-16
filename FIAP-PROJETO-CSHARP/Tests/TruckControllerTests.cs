    using FIAP_PROJETO_CSHARP.Controllers;
    using FIAP_PROJETO_CSHARP.Data;
    using FIAP_PROJETO_CSHARP.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Xunit;

    public class TruckControllerTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly TruckController _controller;

        public TruckControllerTests()
        {
        
            var dbName = Guid.NewGuid().ToString();

       
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            _context = new ApplicationDbContext(options);

       
            SeedDatabase();

        
            _controller = new TruckController(_context);
        }

        private void SeedDatabase()
        {
            var trucks = new List<Truck>
            {
                new Truck
                {
                    Id = 1,
                    PlateCode = "ABC1234",
                    Driver = "Lord",
                    RegistrationDate = DateTime.Now.AddDays(-10),
                    Location = "Xique-xique"
                },
                new Truck
                {
                    Id = 2,
                    PlateCode = "XYZ5678",
                    Driver = "Jack Sparrow",
                    RegistrationDate = DateTime.Now.AddDays(-5),
                    Location = "Rio de Janeiro"
                }
            };

            _context.Trucks.AddRange(trucks);
            _context.SaveChanges();
        }

        [Fact]
        public void Index_ReturnsViewResultWithListOfTrucks()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Truck>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Index_ReturnsSuccessStatusCode()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var statusCode = viewResult.StatusCode ?? 200; 
            Assert.Equal(200, statusCode);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
