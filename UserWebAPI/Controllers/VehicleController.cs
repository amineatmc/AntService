using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController :ControllerBase
    {
        IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        [HttpPost("[action]")]
        public IActionResult Add(Vehicle vehicle)
        {
            var result= _vehicleService.Add(vehicle);
            if (result.Result.Success)
            {
                return Ok(vehicle);
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult AddVehicle([FromForm]VehicleAddDto vehicle)
        {
            var result = _vehicleService.AddVehicle(vehicle);
            if (result.Success)
            {
                //string connectionString = "https://taxi7x24prodstorage.blob.core.windows.net/ruhsat?";
                //string containerName = "./Container/";
                //string blobName = "ruhsat";
                //string imagePath = Path.Combine(vehicle.CarImages[0].FileName);

                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                //CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                //container.CreateIfNotExistsAsync();

                //CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

                //using (var stream = new FileStream(imagePath, FileMode.Open))
                //{
                //    blob.UploadFromStreamAsync(stream);
                //}

                return Ok(vehicle);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _vehicleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("[action]")]
        public IActionResult Update(VehicleUpdateDto vehicleUpdateDto)
        {
            var result = _vehicleService.Update(vehicleUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
