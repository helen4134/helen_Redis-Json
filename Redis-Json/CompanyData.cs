using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Redis_Json
{
    public class CompanyData
    {
        public class Company
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public List<string> Employee { get; set; }
        }

        public string GetJson(string Name, string Address , List<string> Employee)
        {
            Company CompanyAsync = new Company
            {
                Name = Name,
                Address = Address,
                Employee = Employee
            };
            //物件序列化轉成JSON格式
            JsonClass Json = new JsonClass();
            return Json.TransToJson(CompanyAsync);

        }

        public string GetJsonData(string Kind)
        {
            RedisClass redis = new RedisClass();
            string JsonString = (string)redis.GetDataFromRdis("company");

            JsonClass Json = new JsonClass();
            //JSON格式轉成物件
            var Company = Json.JsonToclass(JsonString);
            string GetValue = "";
            if (Kind == "Name")
            {
                GetValue = Company.Name;
            }
            if (Kind == "Address")
            {
                GetValue = Company.Address;
            }
            if (Kind == "Employee")
            {
                GetValue = Company.Employee[0] + ";" +
                   Company.Employee[1] + ";" +
                   Company.Employee[2];
            }
            return GetValue;
        }
    }
}
