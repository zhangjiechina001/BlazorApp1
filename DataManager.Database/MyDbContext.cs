using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<DbSpectrumItem> SpectrumItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "localhost"; // 替换为你的 MySQL 服务器地址
            string port = "3306"; // 默认端口号为 3306
            string database = "MyDb"; // 替换为你的数据库名称
            string username = "root"; // 替换为你的用户名
            string password = "1234"; // 替换为你的密码

            string connectionString = $"Server={server};Port={port};Database={database};User={username};Password={password};";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
