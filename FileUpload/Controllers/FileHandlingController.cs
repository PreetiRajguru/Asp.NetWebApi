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

        //accept directory name and create directory
        [HttpPost]
        [Route("api/CreateNewDirectory")]
        public IActionResult CreateNewDirectory(string FolderName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, FolderName);
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
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

        //accept file to upload to new directory
        [HttpPost]
        [Route("api/UploadFileToDirectory")]
        public IActionResult UploadFile(IFormFile uploadFile, string FolderName)
        {
            try
            {
                string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, FolderName);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filePath = Path.Combine(directoryPath, uploadFile.FileName);

                if (uploadFile.Length < 10485760) //10 MB = 10 * 1024 * 1024 Bytes
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        uploadFile.CopyTo(stream);
                    }
                    return Ok("Upload Successfull");
                }
                else
                {
                    return Ok("Cannot upload file. File size is greater than 10 MB.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }

        //accept directory name to delete
        [HttpPost]
        [Route("api/DeleteDirectory")]
        public IActionResult DeleteDirectory(string directoryName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, directoryName);
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
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





/*[HttpPost]
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
*/