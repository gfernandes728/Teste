﻿using System.Data;
using System.Data.SqlClient;

namespace Teste.Infra
{
    public class DbDapperContext
    {
        private readonly IConfiguration _configuration;

        public DbDapperContext(IConfiguration configuration)
            => _configuration = configuration;

        public virtual IDbConnection DapperConnection
        {
            get { return new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]); }
        }
    }
}
