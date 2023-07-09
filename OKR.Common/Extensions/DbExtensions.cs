using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageCore.DataAccess;
using StorageCore.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Extensions
{
    public static class DbExtensions
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            
          

            //settings db 
            /*services.Configure<SqlDbOptions>(x =>
            {
                x.ConnectionString = connectionString;
            });*/

        }
    }
}
