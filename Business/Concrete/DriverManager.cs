using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DriverManager : IDriverService
    {
        IDriverDal _driverDal;
        public DriverManager(IDriverDal driverDal)
        {
            _driverDal= driverDal;
        }

        public IResult Add(Driver driver)
        {
           //_driverDal.Add(driver);

            string jwtToken;
            var login = (HttpWebRequest)WebRequest.Create("https://antalyataksinode.azurewebsites.net/admins/generatetoken");
            login.PreAuthenticate = true;
            login.ContentType = "application/json";
            login.Method = "POST";
            using (var streamWriterS = new StreamWriter(login.GetRequestStream()))
            {
                string jsonS = "{\"username\":\"" + "admin" + "\"," +
                               "\"password\":\"" + "170718Se." +
                               "\"}";
                streamWriterS.Write(jsonS);
            }
            string Json;

            var httpResponses = (HttpWebResponse)login.GetResponse();
            using (var streamReaderS = new StreamReader(httpResponses.GetResponseStream()))
            {
                Json = streamReaderS.ReadToEnd();
                JObject resultS = JObject.Parse(Json);
                jwtToken = resultS["token"].ToString();
            }


            var entityPost = (HttpWebRequest)WebRequest.Create("https://antalyataksinode.azurewebsites.net/drivers");
            entityPost.PreAuthenticate = true;
            entityPost.ContentType = "application/json";
            entityPost.Method = "POST";
            entityPost.Headers.Add("Authorization", "Bearer " + jwtToken);
            using (var stream = new StreamWriter(entityPost.GetRequestStream()))
            {
                string json = "{\"driverId\":\"" + 1 + "\"," +
                               "\"stationId\":\"" + 1 + "\"," +
                               "\"allUserId\":\"" + 1 + 
                               "\"}";
                stream.Write(json);
            }
            string resultJson;
            try
            {
                var httpResponse = (HttpWebResponse)entityPost.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resultJson = streamReader.ReadToEnd();
                    JObject result = JObject.Parse(resultJson);
                }
            }
            catch (WebException ex)
            {
                var ms = ex.Message;
            }
            return new SuccessResult();

        }

        //public IDataResult<List<Driver>> GetAll()
        //{
        //    return new SuccessDataResult<List<Driver>>(_driverDal.GetList());
        //}

        public IDataResult<List<DriverListDto>> GetAlls()
        {
            return new SuccessDataResult<List<DriverListDto>>(_driverDal.GetDrivers().Where(x=>x.Activity==1).ToList());
        }

        public IDataResult<List<DriverListDto>> GetById(int id)
        {
            return new SuccessDataResult<List<DriverListDto>>(_driverDal.GetDrivers().Where(x=>x.DriverID == id && x.Activity == 1).ToList());
        }

        public IDataResult<List<DriverListDto>> GetByTc(string tc)
        {
            return new SuccessDataResult<List<DriverListDto>>(_driverDal.GetDrivers().Where(x=>x.IdNo==tc && x.Activity==1).ToList());
        }

        public IDataResult<List<DriverUpdateDto>> Update(DriverUpdateDto driver)
        {
            var drv = _driverDal.Get(x => x.DriverID == driver.DriverID);
            if (drv!=null)
            {
                //if (string.IsNullOrWhiteSpace(driver.IdNo)==false)
                     drv.IdNo = driver.IdNo;
              //  if(string.IsNullOrWhiteSpace(driver.DriverLicenseNo)==false)
                    drv.DriverLicenseNo= driver.DriverLicenseNo;              
                    drv.Rating= driver.Rating;               
                    drv.BirthDay = driver.BirthDay;                
                    drv.Pet = driver.Pet;

                _driverDal.Update(drv);
            }
            return new SuccessDataResult<List<DriverUpdateDto>>();

        }
    }
}
