using Dapper;
using LibCore.ServicesInterface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Persistence.Dapper
{
    public interface IProvider : IService
    {
        SqlConnection GetConnection();
    }
    public class Provider: IProvider
    {
        private readonly IConfiguration Configuration;
        public Provider(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public string GetConnectionString()
        {
            string returnValue = Configuration["Data:DefaultConnection:ConnectionString"];

            //ConnectionStringSettings settings =
            //    ConfigurationManager.ConnectionStrings[name];

            //if (settings != null)
            //    returnValue = settings.ConnectionString;

            return returnValue;
        }

        public SqlConnection GetConnection()
        {
            string str = GetConnectionString();
            SqlConnection con = new SqlConnection(str);
            return con;
        }

        

    }
}
