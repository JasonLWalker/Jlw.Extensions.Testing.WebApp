using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Extensions.Testing.WebApp
{
    [TestClass]
    public abstract class WebAppIntegrationFixtureBase<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected HttpClient _client;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                .UseStartup<TStartup>();

            base.ConfigureWebHost(builder);
        }

        [TestInitialize]
        public void TestInit()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<TStartup>();

            _client = this.CreateClient();
        }

    }
}
