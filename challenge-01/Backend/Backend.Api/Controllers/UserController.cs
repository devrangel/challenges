using Backend.Application.DTOs.Users;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult<GetUserDTO>> Get([FromRoute] int id)
        {
            var user = await _service.GetByIdAsync(id);

            if(user == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]PostUserDTO model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.CreateAsync(model);

                // Verifica se nao foi gerado nenhum erro na criacao usuario
                // Caso tenha, result tera uma lista, count > 0, com os erros que aconteceram
                if (result.Count != 0)
                {
                    // Retornar um GetUserDTO que nao contem informacoes sensiveis
                    var modelSend = new GetUserDTO(-1, model.FirstName, model.LastName, model.Email, "");

                    return BadRequest(new { model = modelSend, errorMessage = result });
                }

                return Ok(new { message = "Usuário criado com sucesso" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário"});
            }
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Authenticate([FromBody]AuthUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetAuthUser(user);

                if(result == null)
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }

                return Ok(result);
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Usuário não existe" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult> Put(
            [FromRoute] int id,
            [FromBody] PutUserDTO model)
        {
            if(id != model.Id)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.UpdateAsync(model);

                if(result == null)
                {
                    return NotFound(new { message = "Usuário não encontrado" });
                }

                // Verifica se nao foi gerado nenhum erro na criacao usuario
                // Caso tenha, result tera uma lista, count > 0, com os erros que aconteceram
                if (result.Count != 0)
                {
                    // Retornar um GetUserDTO que nao contem informacoes sensiveis
                    var modelSend = new GetUserDTO(model.Id, model.FirstName, model.LastName, model.Email, "");

                    return BadRequest(new { model = modelSend, errorMessage = result });
                }

                return Ok(new { message = "Usuário atualizado com sucesso"});
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o usuário" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            try
            {
                await _service.RemoveAsync(model.Id);

                return Ok(new { message = "Usuário removido com sucesso" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o usuário" });
            }
        }
    }
}
