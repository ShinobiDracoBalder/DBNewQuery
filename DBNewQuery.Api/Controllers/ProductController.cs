﻿using DBNewQuery.Api.Application.Interfaces;
using DBNewQuery.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBNewQuery.Api.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        //Unit of work to give access to the repositories
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            // Inject Unit Of Work to the contructor of the product controller
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// This endpoint returns all products from the repository
        /// </summary>
        /// <returns>List of product objects</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IReadOnlyList<Product> data = await _unitOfWork.Products.GetAllAsync();
            return Ok(data);
        }
        /// <summary>
        /// This endpoint returns a single product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product data = await _unitOfWork.Products.GetByIdAsync(id);
            if (data == null)
            {
                return Ok();
            }

            return Ok(data);
        }
        /// <summary>
        /// This endpoint adds a product to the database based on Product model
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Status for creation</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            int data = await _unitOfWork.Products.AddAsync(product);
            return Ok(data);
        }
        /// <summary>
        /// This endpont deletes a product form the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status for deletion</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int data = await _unitOfWork.Products.DeleteAsync(id);
            return Ok(data);
        }
        /// <summary>
        /// This endpoint updates a product by ID
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Status for update</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            int data = await _unitOfWork.Products.UpdateAsync(product);
            return Ok(data);
        }
    }
}
