using DBNewQuery.Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DBNewQuery.Api.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EspecialidadController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Speciality.GetAllAsync());
        }
    }
}
