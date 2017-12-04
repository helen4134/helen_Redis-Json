using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redis_Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;


namespace Redis_Json.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        public static ConnectionMultiplexer _redis;
        //[SetUp()]
        public void Setup()
        {
            Form1 target = new Form1();
        }

        public void ConnectRedis()
        {
            try
            {
                if (_redis == null || !_redis.IsConnected)
                    _redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            }
            catch (Exception)
            {
                //exception handling goes here
                //MessageBox.Show("error:" + ex);
            }
        }

        public class Companytest
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public List<string> Employee { get; set; }
        }

        [TestMethod()]
        public void TransToJsonTest()
        {
            //驗證有無成功轉換成json 
            Object companylist = "美佳";
            JsonClass JsonClass = new JsonClass();
            
            string json = JsonClass.TransToJson(companylist);
            Assert.IsTrue(json != null);
        }

        [TestMethod()]
        public void ImportToRdisTest()
        {
            //驗證有無成功將值塞入redis
            ConnectRedis();
            var db = _redis.GetDatabase();
            string s = (string)db.StringGet("company");
            var actual = s;
            Assert.IsTrue(actual != null);
        }

        [TestMethod()]
        public void Btncompany_ClickTest()
        {
            CompanyData Company = new CompanyData();
            string value = Company.GetJsonData("Name");
            Assert.IsTrue(value != null);
            Assert.IsTrue(value == "美佳");
        }


    }
}