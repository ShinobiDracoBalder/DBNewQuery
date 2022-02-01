using Dapper;
using DBNewQuery.Api.Application.Interfaces;
using DBNewQuery.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DBNewQuery.Api.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        /// <summary>
        /// This method adds a new product to the database using Dapper
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        public async Task<int> AddAsync(Product entity)
        {
            // Set the time to the current moment
            entity.Added = DateTime.Now;

            // Basic SQL statement to insert a product into the products table
            var sql = "Insert into Products (Name,Description,Barcode,Price,Added) VALUES (@Name,@Description,@Barcode,@Price,@Added)";

            // Sing the Dapper Connection string we open a connection to the database
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                // Pass the product object and the SQL statement into the Execute function (async)
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        /// <summary>
        /// This method deleted a product specified by an ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        /// <summary>
        /// This method returns all products in database in a list object
        /// </summary>
        /// <returns>IEnumerable Product</returns>
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                // Map all products from database to a list of type Product defined in Models.
                // this is done by using Async method which is also used on the GetByIdAsync
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        /// <summary>
        /// This method returns a single product specified by an ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        /// <summary>
        /// This method updates a product specified by an ID. Added column won't be touched.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        public async Task<int> UpdateAsync(Product entity)
        {
            entity.Modified = DateTime.Now;
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Price = @Price, Modified = @Modified  WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
