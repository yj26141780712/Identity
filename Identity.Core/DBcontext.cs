using Identity.Common;
using Identity.Core.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core
{
    public class DBcontext
    {
        public DBcontext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"],
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string s = sql;
                //Console.WriteLine(sql + "\r\n" +
                //    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };
        }
        public SqlSugarClient Db;

        public SimpleClient<User> userDb => new SimpleClient<User>(Db);
    }
}
