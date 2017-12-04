using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis_Json
{
    class RedisClass
    {
        public static ConnectionMultiplexer _redisAsync;
        public void ConnectRedis()
        {
            try
            {
                if (_redisAsync == null || !_redisAsync.IsConnected)
                    _redisAsync = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error:" + ex);
            }
        }

        public void ImportToRdis(string Name,string Json) //寫入redis
        {
            ConnectRedis();
            var db = _redisAsync.GetDatabase();
            db.KeyDelete(Name);
            db.StringSet(Name, Json);
        }

        public string GetDataFromRdis(string Json)
        {
            ConnectRedis();
            var db = _redisAsync.GetDatabase();
            return  (string)db.StringGet(Json);
        }

    }
}

