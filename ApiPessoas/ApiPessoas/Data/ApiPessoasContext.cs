using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPessoas;

namespace ApiPessoas.Data
{
    public class ApiPessoasContext : DbContext
    {
        public ApiPessoasContext (DbContextOptions<ApiPessoasContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPessoas.PessoaModel> PessoaModel { get; set; } = default!;
    }
}
