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

		public  Form1()
        {
            InitializeComponent();
            CompanyData Company = new CompanyData();
            string Json = Company.GetJson("美佳", "台中市台灣大道上", new List<string>() { "hugo", "fish", "helen" });

            RedisClass Redis = new RedisClass();
            Redis.ImportToRdis("company", Json);
        }


        public void Btncompany_Click(object sender, EventArgs e)
        {

            CompanyData Company = new CompanyData();
            if (sender.Equals(btncompany))
                text1.Text = Company.GetJsonData("Name");
            else if (sender.Equals(btnAddress))
                text1.Text = Company.GetJsonData("Address");
            else
                text1.Text = Company.GetJsonData("Employee");

        }


    }
}
