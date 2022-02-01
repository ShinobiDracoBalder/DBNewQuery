using DBNewQuery.Api.Application.Interfaces;
using DBNewQuery.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBNewQuery.Api.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecialityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSpecialitiesAll()
        {
            IReadOnlyList<Especialidad> data = await _unitOfWork.Speciality.GetAllAsync();
            if (data == null)
            {
                return BadRequest(new Response{
                    IsSuccess = false,
                    Message = "Specialities Doesnt Exists"
                });
            }

            return Ok(data);
        }
        /// <summary>
        /// This endpoint returns a single product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            Especialidad data = await _unitOfWork.Speciality.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Speciality Doesnt Exist"
                });
            }

            return Ok(data);
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Especialidad))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(Especialidad especialidad)
        {
            int data = await _unitOfWork.Speciality.AddAsync(especialidad);
            if (data!=1){
                return BadRequest(new Response{
                    IsSuccess = false,
                    Message = "Unable to perform the specified registration or Duplic"
                });
            }
            return Ok(data);
        }

        /// <summary>
        /// This endpont deletes a product form the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status for deletion</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            int data = await _unitOfWork.Speciality.DeleteAsync(id);
            if (data != 1)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Unable to perform the specified(Deteled) registration"
                });
            }
            return Ok(data);
        }
        /// <summary>
        /// This endpoint updates a product by ID
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Status for update</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Especialidad especialidad)
        {
            int data = await _unitOfWork.Speciality.UpdateAsync(especialidad);
            if (data != 1)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Unable to perform the specified(Update) registration"
                });
            }

            return Ok(data);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetUSPEspecialidad")]
        public async Task<IActionResult> GetUSPEspecialidad()
        {
            List<Especialidad> data = await _unitOfWork.Speciality.GetEspecialidadesAsync();
            if (data == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Specialities Doesnt Exists"
                });
            }

            return Ok(data);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("UpdateEspecialidad")]
        public async Task<IActionResult> UpdateEspecialidad(Especialidad model)
        {
            Response data = await _unitOfWork.Speciality.UpdateEspecialidadAsync(model);
            if (!data.IsSuccess)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = data.Message,
                });
            }

            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("InsertEspecialidad")]
        public async Task<IActionResult> InsertEspecialidad(Especialidad model)
        {
            Response data = await _unitOfWork.Speciality.InsertEspecialidadAsync(model);
            if (!data.IsSuccess)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = data.Message,
                });
            }

            return Ok(data);
        }
    }
}
