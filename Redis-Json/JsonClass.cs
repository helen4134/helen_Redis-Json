using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace Redis_Json
{
	public class JsonClass
	{
        
        public class Company
        {
			public string Name { get; set; }
			public string Address { get; set; }
			public List<string> Employee { get; set; }
		}

		public string TransToJson(object comanylist)  //轉成JSON格式
		{
		    return JsonConvert.SerializeObject(comanylist);
	    }

        public Company JsonToclass(string companylist) //轉成物件
		{
			return JsonConvert.DeserializeObject<Company>(companylist);
		}

	}
}
