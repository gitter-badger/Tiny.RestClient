using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Tiny.Http.Tests.Models;

namespace Tiny.Http.Tests
{
    [TestClass]
    public class TimeoutTests : BaseTest
    {
        [ExpectedException(typeof(TimeoutException))]
        [TestMethod]
        public async Task TimeoutTest()
        {
            var client = GetClient();
            client.Settings.DefaultTimeout = TimeSpan.FromMilliseconds(1);
            var data = await client.
              GetRequest("TimeoutTest/Action400ms").
              ExecuteAsync<string>();

            Debug.WriteLine(data);
        }
    }
}