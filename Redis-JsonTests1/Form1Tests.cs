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
        //[SetUp]
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

        public class companytest
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public List<string> Employee { get; set; }
        }

        [TestMethod()]
        public void TransToJsonTest()
        {
            //驗證有無成功轉換成json ??
            Form1 c = new Form1();
            companytest companylist = new companytest
            {
                Name = "美佳",
                Address = "台中市台灣大道上",
                Employee = new List<string>
                {
                    "hugo",
                    "fish",
                    "helen"
                }
            };
            //var companyJson = c.TransToJson(companylist);
            //Assert.IsTrue(companyJson != null);
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
        public void btncompany_ClickTest()
        {
            //驗證有無成功將值取出    ??
            //驗證有無成功將json 反序列化回class 並且值是正確的
            //ConnectRedis();
            //var db = _redis.GetDatabase();
            //string s = (string)db.StringGet("company");

            // Form1 target = new Form1();
            //Assert.IsTrue(s == s1);
        }

        [TestMethod()]
        public void JsonToclassTest()
        {
            //驗證有無成功將json 反序列化回class 並且值是正確的
            ConnectRedis();
            var db = _redis.GetDatabase();
            string s = (string)db.StringGet("company");

            Form1 c = new Form1();
            var companylist = c.JsonToclass(s);
            
            Assert.IsTrue((string)companylist.Name == "美佳");
            Assert.IsTrue((string)companylist.Address == "台中市台灣大道上");
            Assert.IsTrue((string)companylist.Employee[0] == "hugo");
            Assert.IsTrue((string)companylist.Employee[1] == "fish");
            Assert.IsTrue((string)companylist.Employee[2] == "helen");
        }
    
    }
}