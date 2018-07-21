using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Controllers;

namespace Test
{
    public class UnitTest1
    {
        private BloggingContext _context;
        private BlogsController _controller;
        public UnitTest1()
        {
            _context = GetContextWithData();
            _controller = new BlogsController(_context);
        }
        
        private static BloggingContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "efkata1")
                .Options;
            
            var context = new BloggingContext(options);

            context.Blogs.RemoveRange(context.Blogs.ToList());
            context.SaveChanges();
            context.Blogs.Add(new Blog
            {
                BlogId = 1,
                Url = "here",
                Posts = new List<Post>()
            });
            context.SaveChanges();

            return context;
        }
        
        [Fact]
        public void Test1()
        {
            var results = _controller.Get();
            Assert.Equal(1, results.Count());
        }

        [Fact]
        public async void AsyncTest()
        {
            var results = await _controller.GetAsync();
            Assert.Equal(1, results.Count());
        }
    }
}