using System;
using System.Linq;
using Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastruture.Repositories.Data
{
    public static class SeedData
    {
        public static void Initialize(trayprojeto45DbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pessoas.Any())
            {
                return;   // O banco de dados já foi preenchido.
            }

            var pessoas = new[]
            {
                new Pessoa("Alice Silva", "alice@example.com", "senha123"),
                new Pessoa("Bruno Costa", "bruno@example.com", "senha456")
            };

            context.Pessoas.AddRange(pessoas);
            context.SaveChanges();
        }
    }
}