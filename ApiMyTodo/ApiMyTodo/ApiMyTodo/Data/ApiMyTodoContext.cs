using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiMyTodo.Models;
using Microsoft.Extensions.Configuration;

namespace ApiMyTodo.Data
{
    public class ApiMyTodoContext : DbContext
    {
        private readonly IConfiguration _configuration;


        //Konstruktor
        public ApiMyTodoContext(DbContextOptions<ApiMyTodoContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        //Tabele bazy danych**********************
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        //*************************************




        //Konfiguracja połaczenia z bazą danych
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ApiMyTodoContext"));
        }
    }
}
