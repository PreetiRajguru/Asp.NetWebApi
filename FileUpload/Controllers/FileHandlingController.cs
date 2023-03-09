using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileHandlingController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileHandlingController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Create Directory
        /// </summary>
        //accept directory name and create directory
        [HttpPost]
        [Route("create_directory")]
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

        /// <summary>
        /// Upload file
        /// </summary>
        //accept file to upload to new directory
        [HttpPost]
        [Route("upload_file_to_directory")]
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

        /// <summary>
        /// Display all customers
        /// </summary>
        //accept directory name to delete
        [HttpDelete]
        [Route("delete_directory")]
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