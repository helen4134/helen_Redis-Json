using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;


namespace Redis_Json
{
    public partial class Form1 : Form
    {
        public static ConnectionMultiplexer _redis;
        public string mresult;
        public company companylist;

        public class company
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public List<string> Employee { get; set; }
        }


        public  Form1()
        {
            InitializeComponent();
            company companylist = new company
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

            //轉成JSON格式
            string json = TransToJson(companylist);
            ImportToRdis(json);
        }

        public string TransToJson(company companylist )
        {
            return JsonConvert.SerializeObject(companylist);
        }

        public void ConnectRedis()
        {
            try
            {
                if (_redis == null || !_redis.IsConnected)
                   _redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            }
            catch (Exception ex)
            {               
                MessageBox.Show("error:" +ex);
            }
        }


        public void ImportToRdis(string json) //寫入redis
        {
            ConnectRedis();
            var db = _redis.GetDatabase();
            db.KeyDelete("company");            
            db.StringSet("company", json);
        }


        public void btncompany_Click(object sender, EventArgs e)
        {
            ConnectRedis();
            var db = _redis.GetDatabase();
            //讀取redis
            string s = (string)db.StringGet("company");

            //轉成物件
            company companyname = JsonToclass(s);
            if (sender.Equals(btncompany))
                text1.Text = companyname.Name;
            else if (sender.Equals(btnAddress))
                text1.Text = companyname.Address;
            else
                text1.Text = companyname.Employee[0] + ";" +
                             companyname.Employee[1] + ";" +
                             companyname.Employee[2];

            mresult = text1.Text;
        }


        public company JsonToclass(string companylist) //轉成物件
        {
            return JsonConvert.DeserializeObject<company>(companylist);
        }
    }
}
