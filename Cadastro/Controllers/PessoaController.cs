using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Cadastro.Context;
using Cadastro.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Controllers
{
    [Route("Cadastro-pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase // Alterado para ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PessoaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            return Ok(new
            {
                success = true,
                data = await _appDbContext.Pessoa.ToListAsync()

            });


        }

        [HttpPost]

        public async Task<IActionResult> CriarPessoa(Pessoa pessoa)
        {

            _appDbContext.Pessoa.Add(pessoa);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = pessoa
            });


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoasId(int id)
        {
            var pessoa = await _appDbContext.Pessoa.FirstOrDefaultAsync(p => p.Id == id && p.Situacao == true);
            if (pessoa == null) { return NotFound(new { success = false, message = "Pessoa não encontrada." });
            }
            return Ok(
                new 
                {
                    success = true,
                    data = pessoa
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = await _appDbContext.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

            if (pessoa == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Pessoa não encontrada."
                });
            }

            // Atualizar os dados
            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Nascimento = pessoaAtualizada.Nascimento;
            pessoa.Situacao = pessoaAtualizada.Situacao;
            pessoa.Nacionalidade = pessoaAtualizada.Nacionalidade;
            pessoa.Rg = pessoaAtualizada.Rg;
            pessoa.Passaporte = pessoaAtualizada.Passaporte;
            pessoa.Idade = pessoaAtualizada.Idade;

            // Atualize outros campos conforme necessário

            try
            {
                _appDbContext.Pessoa.Update(pessoa);
                await _appDbContext.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Pessoa atualizada com sucesso.",
                    data = pessoa
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Erro ao atualizar pessoa.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Exclusao(int id)
        { 
            var pessoa = await _appDbContext.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

            if (pessoa == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Pessoa não encontrada."
                });
            }

            // Atualizar os dados
            pessoa.Situacao = false;
            // Atualize outros campos conforme necessário

            try
            {
                _appDbContext.Pessoa.Update(pessoa);
                await _appDbContext.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Pessoa atualizada com sucesso.",
                    data = pessoa
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Erro ao atualizar pessoa.",
                    error = ex.Message
                });
            }
        }
    }
}
