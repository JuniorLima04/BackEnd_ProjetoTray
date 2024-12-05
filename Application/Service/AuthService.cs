using Core.IRepositories;
using Core.IService;
using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryPessoa _repositoryPessoa;
        private readonly IConfiguration _configuration;

        public AuthService(IRepositoryPessoa repositoryPessoa, IConfiguration configuration)
        {
            _repositoryPessoa = repositoryPessoa;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string email, string senha)
        {
            var pessoa = await _repositoryPessoa.GetByIdAsync(email);
            if (pessoa == null || pessoa.Senha != senha)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            return GenerateJwtToken(pessoa);
        }

        private string GenerateJwtToken(Pessoa pessoa)
        {
            var claims = new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, pessoa.Nome),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, pessoa.Email),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, pessoa.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}