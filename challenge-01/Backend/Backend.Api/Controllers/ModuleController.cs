using Backend.Application.DTOs.Modules;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/v1/modules")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;

        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<GetModuleDTO>>> Get()
        {
            var modules = await _service.GetAllAsync();

            if (modules == null)
            {
                return NotFound(new { message = "Módulos não encontrados" });
            }

            return Ok(modules);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetModuleDTO>> GetById(int id)
        {
            var module = await _service.GetByIdAsync(id);

            if (module == null)
            {
                return NotFound(new { message = "Módulo não encontrado" });
            }

            return Ok(module);
        }

        [HttpPost]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Post([FromBody] PostModuleDTO model)
        {
            if (!ModelState.IsValid)
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
                    return BadRequest(new { model = model, errorMessage = result });
                }

                return Ok(new { message = "Módulo adicionado com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar o módulo" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Put(
            [FromRoute] int id,
            [FromBody] PutModuleDTO model)
        {
            if (id != model.Id)
            {
                return NotFound(new { message = "Módulo não encontrado" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.UpdateAsync(model);

                if (result == null)
                {
                    return NotFound(new { message = "Módulo não encontrado" });
                }

                // Verifica se nao foi gerado nenhum erro na criacao usuario
                // Caso tenha, result tera uma lista, count > 0, com os erros que aconteceram
                if (result.Count != 0)
                {
                    return BadRequest(new { model = model, errorMessage = result });
                }

                return Ok(new { message = "Módulo atualizado com sucesso" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o módulo" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound(new { message = "Módulo não encontrado" });
            }

            try
            {
                await _service.RemoveAsync(model.Id);

                return Ok(new { message = "Módulo removido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o módulo" });
            }
        }
    }
}
