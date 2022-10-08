﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using StreamTec.Controllers;
using StreamTec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Assert = Xunit.Assert;

namespace StreamTecTest
{
    public class XUnit
    {
        private DbContextOptions<WelTecContext> dbContextOptions;
        Mock<HttpContext> mockHttpContext;


        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WelTecContext _context;
        public XUnit(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void SearchTest()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
            .UseInMemoryDatabase(databaseName: "localdb")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 5, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }
            
            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var testStudentId = "3333333";                
                // Act
                var adminController = new AdminController(context);
                var view = adminController.Search(testStudentId);
                var result = context.Enrollments.FirstOrDefault(s => s.StudentId == testStudentId);
                // Assert
                Assert.Equal(testStudentId, result.StudentId.ToString());
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void SearchTestInvalid()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
            .UseInMemoryDatabase(databaseName: "localdb")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 5, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 6, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var testStudentId = "ab";
                // Act
                var adminController = new AdminController(context);
                var view = adminController.Search(testStudentId);
                var result = context.Enrollments.ToList().Where(s => s.StudentId.Contains(testStudentId));
                // Assert
                Assert.Equal(0.ToString(), result.Count().ToString());
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void DeleteTest()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
                .UseInMemoryDatabase(databaseName: "localdb")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var deleteId = 2;
                var test = context.Enrollments.ToList();
                Assert.Equal("4", test.Count.ToString());

                // Act
                var adminController = new AdminController(context);
                var view = adminController.Delete(deleteId);
                var testDeleted = context.Enrollments.ToList();

                // Assert
                _testOutputHelper.WriteLine(testDeleted.Count.ToString());
                Assert.Equal("3", testDeleted.Count.ToString());
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void DeleteTestInvalid()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
                .UseInMemoryDatabase(databaseName: "localdb")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var deleteId = 8;
                var test = context.Enrollments.ToList();
                Assert.Equal("4", test.Count.ToString());

                // Act 
                var adminController = new AdminController(context);
                var view = adminController.Delete(deleteId);
                var testDeleted = context.Enrollments.ToList();

                // Assert
                _testOutputHelper.WriteLine(testDeleted.Count.ToString());
                Assert.Equal("4", testDeleted.Count.ToString());
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void AddTest()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
                .UseInMemoryDatabase(databaseName: "localdb")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange 
                string studentID = "2208266";
                string streamID = "IT-5115-Com-A-03";
                var test = context.Enrollments.ToList();
                Assert.Equal("4", test.Count.ToString());
                _testOutputHelper.WriteLine(test.Count.ToString());

                // Act
                var adminController = new AdminController(context);
                var view = adminController.Add(streamID, studentID);
                var testAdded = context.Enrollments.ToList();

                // Assert
                _testOutputHelper.WriteLine(testAdded.Count.ToString());
                Assert.Equal("5", testAdded.Count.ToString());
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void AddTestInvalid()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
                .UseInMemoryDatabase(databaseName: "localdb")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                string studentID = "a";
                string streamID = "a";
                var test = context.Enrollments.ToList();
                Assert.Equal("4", test.Count.ToString());
                _testOutputHelper.WriteLine(test.Count.ToString());

                // Act
                var adminController = new AdminController(context);
                var view = adminController.Add(studentID, streamID);
                var testAdded = context.Enrollments.ToList();

                // Assert
                _testOutputHelper.WriteLine(testAdded.Count.ToString());
                Assert.Equal("4", testAdded.Count.ToString());
                Assert.True(view.IsFaulted);
            }
        }

        [Fact]
        public void AdminIndexTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WelTecContext>()
             .UseInMemoryDatabase(databaseName: "localdb")
             .Options;
            // Act
            var adminController = new AdminController(_context);
            var result = adminController.Index() as ViewResult;
            // Assert
            Assert.Equal("AdminHome", result.ViewName);
        }

        [Fact]
        public void HomeIndexTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WelTecContext>()
             .UseInMemoryDatabase(databaseName: "localdb")
             .Options;
            // Act
            var adminController = new HomeController(_context);
            var result = adminController.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void RegisterTest()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
               .UseInMemoryDatabase(databaseName: "localdb")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var student = new Student { StudentId = "8888888", Email = "eight@email.com" };
                var test = context.Students.ToList();
                Assert.Equal("1", test.Count.ToString());

                // Act
                var homeController = new HomeController(context);
                var view = homeController.Register(student);
                var testRegister = context.Students.ToList();

                // Assert
                Assert.Equal("2", testRegister.Count.ToString());
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void RegisterTestDuplicate()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
               .UseInMemoryDatabase(databaseName: "localdb")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Students.Add(new Student { StudentId = "1111111", Email = "one@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var student = new Student { StudentId = "1111111", Email = "one@email.com" };
                var test = context.Students.ToList();
                Assert.Equal("1", test.Count.ToString());

                // Act
                var homeController = new HomeController(context);
                var view = homeController.Register(student);
                var testRegister = context.Students.ToList();

                // Assert
                Assert.Equal("1", testRegister.Count.ToString());
                Assert.True(view.IsFaulted);
            }
        }

        [Fact]
        public async void HomeLoginTest()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
               .UseInMemoryDatabase(databaseName: "localdb")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Students.Add(new Student { StudentId = "1111111", Email = "one@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Arrange
                var student = new Student { StudentId = "2208266", Email = "ethan@email.com" };

                // Act
                var homeController = new HomeController(context);
                var view = homeController.Index(student);

                // Assert
                Assert.True(view.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public void HomeLogoutTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WelTecContext>()
             .UseInMemoryDatabase(databaseName: "localdb")
             .Options;
            var student = new Student { StudentId = "2208266", Email = "ethan@email.com" };
            // Act
            var homeController = new HomeController(_context);
            var logout = homeController.Index(student);
            // Assert
            Assert.True(logout.IsCompletedSuccessfully);
        }

        [Fact]
        public void StreamIndexTest()
        {
            var options = new DbContextOptionsBuilder<WelTecContext>()
             .UseInMemoryDatabase(databaseName: "localdb")
             .Options;


            // Insert seed data into the database using one instance of the context
            using (var context = new WelTecContext(options))
            {
                context.Enrollments.Add(new Enrollment { EnrollmentID = 1, StudentId = "2208266", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 2, StudentId = "1111111", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 3, StudentId = "2222222", StreamID = "IT-5115-Com-A-03" });
                context.Enrollments.Add(new Enrollment { EnrollmentID = 4, StudentId = "3333333", StreamID = "IT-5115-Com-A-03" });
                context.Students.Add(new Student { StudentId = "2208266", Email = "ethan@email.com" });
                context.Streams.Add(new StreamTec.Models.Stream { StreamID = "IT-5115-Com-A-03", Room = "T605", Credits = 15, Day = "Monday", StartTime = "0800", EndTime = "1000", Capacity = 24 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WelTecContext(options))
            {
                // Act
                var streamController = new StreamController(context);
                var result = streamController.Index() as ViewResult;
                // Assert
                _testOutputHelper.WriteLine(result.ToString());
                Assert.IsType<ViewResult>(result);
            }              
        }
    }
}