using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        IFileService _fileService;
        IPermitImageService _permitImageService;
        public VehicleManager(IVehicleDal vehicleDal, IFileService fileService, IPermitImageService permitImageService)
        {
            _vehicleDal = vehicleDal;
            _fileService = fileService;
            _permitImageService = permitImageService;
        }

        public async Task<IResult> Add(Vehicle entity)
        {
            entity.CreatedDate= DateTime.Now;
            entity.Activity = 1;
           _vehicleDal.Add(entity);
            return new SuccessResult();
        }

        public IResult AddVehicle(VehicleAddDto entity)
        {
            var data = _vehicleDal.Get(x => x.Plate == entity.Plate);
            if (data!=null)
            {
                return new ErrorResult("Plaka Kaydı Mevcut.");
            }
            var vehicle = new Vehicle();
            vehicle.CreatedDate= DateTime.Now;
            vehicle.Activity= 1;
            vehicle.Plate=entity.Plate;
            vehicle.EngineNo=entity.EngineNo;
            vehicle.ChasisNo=entity.ChasisNo;
            vehicle.LicenseDate=entity.LicenseDate;
            vehicle.LicenseNo=entity.LicenseNo;
            vehicle.LicenseExpiryDate=entity.LicenseExpiryDate;
            vehicle.TaximeterType=entity.TaximeterType;
            vehicle.Ip=entity.Ip;
            vehicle.Ceza=entity.Ceza;
            vehicle.CreatedUser=entity.CreatedUser;

            if (entity.CarImages!=null)
            {
                _vehicleDal.Add(vehicle);
                foreach (var item in entity.CarImages)
                {
                    string fileName = _fileService.FileSaveToServer(item, "./Content/");
                    PermitImage permitImageTbl = new()
                    {
                        VehicleId = vehicle.VehicleID,
                        Path = fileName
                    };

                    _permitImageService.Add(permitImageTbl);
                }
            }
            else
            {
                return new ErrorResult(Messages.CarListNull, 404);
            }
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
          var result = _vehicleDal.Get(x=>x.VehicleID == id && x.Activity == 1 );
            if (result!=null)
            {
                result.Activity = 0;
                _vehicleDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetList().Where(x=>x.Activity==1).ToList());
        }

        public IDataResult<Vehicle> GetbyId(int id)
        {
            var result = _vehicleDal.Get(x => x.VehicleID == id && x.Activity==1);
            return new SuccessDataResult<Vehicle>(result);
        }     

        public IDataResult<VehicleUpdateDto> Update(VehicleUpdateDto vehicleUpdateDto)
        {
            var result = _vehicleDal.Get(x=>x.VehicleID== vehicleUpdateDto.VehicleID && x.Activity == 1);
            if (result!=null)
            {
                result.Plate = vehicleUpdateDto.Plate;
                result.EngineNo= vehicleUpdateDto.EngineNo;
                result.ChasisNo= vehicleUpdateDto.ChasisNo;
                result.LicenseNo= vehicleUpdateDto.LicenseNo;
                result.LicenseDate= vehicleUpdateDto.LicenseDate;
                result.LicenseExpiryDate= vehicleUpdateDto.LicenseExpiryDate;
                result.TaximeterType= vehicleUpdateDto.TaximeterType;
                _vehicleDal.Update(result);
                return new SuccessDataResult<VehicleUpdateDto>(vehicleUpdateDto);
            }

            return new ErrorDataResult<VehicleUpdateDto>();
        }
    }
}
