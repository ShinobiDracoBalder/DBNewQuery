using Dapper;
using DBNewQuery.Api.Application.Interfaces;
using DBNewQuery.Common.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DBNewQuery.Api.Application.Repositories
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly IConfiguration _configuration;

        public EspecialidadRepository(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public async Task<int> AddAsync(Especialidad entity)
        {
            // Basic SQL statement to insert a product into the products table
            var sql = "Insert into [dbo].[Especialidad](EspecialidadNombre)VALUES(@EspecialidadNombre)";

            // Sing the Dapper Connection string we open a connection to the database
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    var Duplic = await GetByNameAsync(entity.EspecialidadNombre);
                    if (Duplic != null)
                    {
                        return -1;
                    }
                    connection.Open();
                    // Pass the product object and the SQL statement into the Execute function (async)
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
                catch (System.Exception)
                {
                    return 0;
                }
                finally {
                    connection.Close();
                }
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM [dbo].[Especialidad] WHERE EspecialidadId = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { Id = id });
                    return result;
                }
                catch (System.Exception)
                {
                    return 0;
                }
                finally {
                    connection.Close();
                }
            }
        }
        public async Task<IReadOnlyList<Especialidad>> GetAllAsync()
        {
            var sql = "SELECT * FROM [dbo].[Especialidad] ";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    connection.Open();

                    // Map all products from database to a list of type Product defined in Models.
                    // this is done by using Async method which is also used on the GetByIdAsync
                    var result = await connection.QueryAsync<Especialidad>(sql);
                    return result.ToList();
                }
                catch (System.Exception)
                {
                    return null;
                }
                finally {
                    connection.Close();
                }
            }
        }
        public async Task<Especialidad> GetByIdAsync(int id)
        {

            var sql = "SELECT * FROM [dbo].[Especialidad] WHERE EspecialidadId = @EspecialidadId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<Especialidad>(sql, new { EspecialidadId = id });
                    return result;
                }
                catch (System.Exception)
                {
                    return null;
                }
                finally {
                    connection.Close();
                }
            }
        }
        public async Task<List<Especialidad>> GetByNameAsync(string Nombre)
        {
            var sql = "SELECT * FROM [dbo].[Especialidad] WHERE EspecialidadNombre = @EspecialidadNombre";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Especialidad>(sql, new { EspecialidadNombre = Nombre });
                    return result.ToList();
                }
                catch (System.Exception)
                {
                    return null;
                }
                finally
                { 
                    connection.Close();
                }
            }
        }
        public async Task<List<Especialidad>> GetEspecialidadesAsync()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                var sql = "[dbo].[usp_GetEspecialidad]";
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Especialidad>(sql);
                    return result.ToList();
                }
                catch (System.Exception)
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<Response> InsertEspecialidadAsync(Especialidad objEsp)
        {
            var sql = "[dbo].[usp_insertEspecialidad]";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    var objInsert = await GetByNameAsync(objEsp.EspecialidadNombre);
                    if (objInsert.Count > 0)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "Doesnt Register Exit!",
                        };
                    }
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@EspecialidadNombre", objEsp.EspecialidadNombre);
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "The record was successfully Insert"
                    };
                }
                catch (System.Exception exception)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = exception.Message,
                    };
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<int> UpdateAsync(Especialidad entity)
        {
            
            var sql = "UPDATE [dbo].[Especialidad] SET EspecialidadNombre = @EspecialidadNombre  WHERE EspecialidadId = @EspecialidadId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    var Duplic = await GetByNameAsync(entity.EspecialidadNombre);
                    if (Duplic != null)
                    {
                        return -1;
                    }
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
                catch (System.Exception)
                {
                    return 0;
                }
                finally {
                    connection.Close();
                }
            }
        }
        public async Task<Response> UpdateEspecialidadAsync(Especialidad entity)
        {
            var sql = "[dbo].[usp_updateEspecialidad]";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                try
                {
                    var objUpdate = await GetByIdAsync(entity.EspecialidadId);
                    if (objUpdate == null)
                    {
                        return new Response {
                            IsSuccess = false,
                            Message ="Doesnt Register Exit!",
                        };
                    }
                    connection.Open();
                    objUpdate.EspecialidadNombre = entity.EspecialidadNombre ?? objUpdate.EspecialidadNombre;
                    var result = await connection.ExecuteAsync(sql, objUpdate, commandType: CommandType.StoredProcedure);
                    return new Response {
                        IsSuccess = true,
                        Message = "The record was successfully updated"
                    };
                }
                catch (System.Exception exception)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = exception.Message,
                    };
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
