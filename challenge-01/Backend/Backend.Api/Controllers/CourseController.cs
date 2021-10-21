using Backend.Application.DTOs.Courses;
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
    [Route("api/v1/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<GetCourseDTO>>> Get()
        {
            var courses = await _service.GetAllAsync();

            if(courses == null)
            {
                return NotFound(new { message = "Cursos não encontrados" });
            }

            return Ok(courses);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetCourseDTO>> GetById([FromRoute] int id)
        {
            var course = await _service.GetByIdAsync(id);

            if(course == null)
            {
                return NotFound(new { message = "Curso não encontrado" });
            }

            return Ok(course);
        }

        [HttpGet]
        [Route("modules/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<GetCourseDTO>>> GetByModule([FromRoute] int id)
        {
            var courses = await _service.GetByModule(id);

            if (courses == null)
            {
                return NotFound(new { message = "Cursos não encontrados" });
            }

            return Ok(courses);
        }

        [HttpPost]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Post([FromBody] PostCourseDTO model)
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
                    return BadRequest(new { model = model, errorMessage = result });
                }

                return Ok(new { message = "Curso adicionado com sucesso" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar o curso" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Put(
            [FromRoute] int id,
            [FromBody] PutCourseDTO model)
        {
            if(id != model.Id)
            {
                return NotFound(new { message = "Curso não encontrado" });
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.UpdateAsync(model);

                if(result == null)
                {
                    return NotFound(new { message = "Curso não encontrado" });
                }

                // Verifica se nao foi gerado nenhum erro na criacao usuario
                // Caso tenha, result tera uma lista, count > 0, com os erros que aconteceram
                if (result.Count != 0)
                {
                    return BadRequest(new { model = model, errorMessage = result });
                }

                return Ok(new { message = "Curso atualizado com sucesso" });
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o curso" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "staff")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var model = await _service.GetByIdAsync(id);

            if(model == null)
            {
                return NotFound(new { message = "Curso não encontrado" });
            }

            try
            {
                await _service.RemoveAsync(model.Id);

                return Ok(new { message = "Curso removido com sucesso" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o curso" });
            }
        }
    }
}
