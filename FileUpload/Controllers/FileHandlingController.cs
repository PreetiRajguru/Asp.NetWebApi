using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileHandlingController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileHandlingController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("api/UploadMultipleFiles")]
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
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Ok("Upload Successfull");
        }




        [HttpPost]
        [Route("api/CreateDirectory")]
        public IActionResult CreateDirectory(string directoryName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, directoryName);
            try
            {
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                    return Ok("Directory created successfully");
                }
                else
                {
                    return BadRequest("Directory already exists");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating directory: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/UploadFile")]
        public IActionResult UploadFile(string filePath, string directoryName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, directoryName);
            //string filePath = Path.Combine(directoryPath, file.FileName);

            try
            {
                if (Directory.Exists(directoryName))
                {
                    var fileName = Path.GetFileName(filePath);
                    var fullPath = Path.Combine(directoryName, fileName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        return BadRequest("File already exists in directory");
                    }
                    else
                    {
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            Request.Body.CopyToAsync(fileStream).Wait();
                        }
                        return Ok("File uploaded successfully");
                    }
                }
                else
                {
                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                    return Ok("Directory created successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/DeleteDirectory")]
        public IActionResult DeleteDirectory(string directoryName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, directoryName);
            try
            {
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                    return Ok("Directory deleted successfully");
                }
                else
                {
                    return BadRequest("Directory does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting directory: {ex.Message}");
            }
        }

    }
}
