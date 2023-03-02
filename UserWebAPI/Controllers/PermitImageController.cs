using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitImageController : ControllerBase
    {
        IPermitImageService _permitImageService;
        public PermitImageController(IPermitImageService permitImageService)
        {
            _permitImageService = permitImageService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByVehicleId(int id)
        {
            var result = _permitImageService.GetListByVehicleId(id);
            if (result.Success)
            {
                #region
                //string connectionString = "https://taxi7x24prodstorage.blob.core.windows.net/ruhsat?";
                //string containerName = "./Container/";
                //string blobName = "ruhsat";

                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                //CloudBlobContainer container = blobClient.GetContainerReference(containerName);

                //CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

                //using (var memoryStream = new MemoryStream())
                //{
                //    blob.DownloadToStreamAsync(memoryStream);
                //    var bytes = memoryStream.ToArray();

                //    return new FileContentResult(bytes, "image/jpeg");
                #endregion
                var fileName = result.Data[0].Path;
                var filePath = Path.Combine("./Content", fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return new FileStreamResult(fileStream, "image/jpeg");

            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByImg(string img)
        {
            var result = _permitImageService.GetListByImg(img);
            if (result.Success)
            {           
                var fileName = result.Data[0].Path;
                var filePath = Path.Combine("./Content", fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return new FileStreamResult(fileStream, "image/jpeg");

            }
            return BadRequest();
        }
    }
}
