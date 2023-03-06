using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        //[HttpPost ("[action]")]
        /*[HttpPost]
        public IActionResult UploadFiles(List<IFormFile> files, string FolderName)
        {
            if (files.Count == 0)
                return BadRequest();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, FolderName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }   

            foreach (var file in files) 
            {
                string filePath = Path.Combine(directoryPath, file.FileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);    
                }
            }
            return Ok("Upload Successfull");
        }*/

        [HttpPost]
        public IActionResult UploadFiles(List<IFormFile> files, string FolderName, string FileName)
        {
            if (files.Count == 0)
                return BadRequest();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, FolderName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            foreach (var file in files)
            {
                string filePath = Path.Combine(directoryPath, FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    /*file.CopyTo(stream);*/
                }
            }
            return Ok("Upload Successfull");
        }


    }
}
