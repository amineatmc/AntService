using Autofac.Core;
using Business.Abstract;
using Business.Aspects;
using Core.Entities;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BoundaryManager : IBoundaryService
    {
        IBoundaryDal _boundrayDal;
        IHttpContextAccessor _contextAccessor;

        public BoundaryManager(IBoundaryDal boundaryDal, IHttpContextAccessor contextAccessor)
        {
            _boundrayDal = boundaryDal;
            _contextAccessor = contextAccessor;
        }

        public IResult Add(Boundary boundary)
        {
            string jwtToken;
            boundary.IsDeleted=false;
            boundary.CreatedDate = DateTime.Now;
            _boundrayDal.Add(boundary);
            try
            {

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


                var entityPost = (HttpWebRequest)WebRequest.Create("https://antalyataksinode.azurewebsites.net/boundaries");
                entityPost.PreAuthenticate = true;
                entityPost.ContentType = "application/json";
                entityPost.Method = "POST";
                entityPost.Headers.Add("Authorization", "Bearer " + jwtToken);
                using (var stream = new StreamWriter(entityPost.GetRequestStream()))
                {
                    string json = "{\"stationId\":\"" + Convert.ToInt32(boundary.StationID) + "\"," +
                                   "\"boundaryId\":\"" + Convert.ToInt32(boundary.BoundaryID) + "\"," +
                                   "\"latitude\":\"" + boundary.Lat + "\"," +
                                   "\"longitude\":\"" + boundary.Long +
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
            }
            catch (Exception)
            {
                return new SuccessResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var entity = _boundrayDal.Get(x => x.BoundaryID == id && x.IsDeleted == false);
            if (entity == null)
            {
                return new ErrorResult("kayıt yok");
            }
            entity.IsDeleted = true;
            _boundrayDal.Update(entity);

            try
            {
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


                var entityPost = (HttpWebRequest)WebRequest.Create("https://antalyataksinode.azurewebsites.net/boundaries/" + entity.BoundaryID);
                entityPost.PreAuthenticate = true;
                entityPost.ContentType = "application/json";
                entityPost.Method = "DELETE";
                entityPost.Headers.Add("Authorization", "Bearer " + jwtToken);
                using (var stream = new StreamWriter(entityPost.GetRequestStream()))


                    try
                    {
                        var httpResponse = (HttpWebResponse)entityPost.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var resultJson = streamReader.ReadToEnd();
                            JObject result = JObject.Parse(resultJson);
                        }
                    }
                    catch (WebException ex)
                    {
                        var ms = ex.Message;
                    }
            }
            catch (Exception)
            {
                return new SuccessResult();
            }

            return new SuccessResult();
        }


        // [SecuredOperation("1")]
        public IDataResult<List<Boundary>> GetAll()
        {
            return new SuccessDataResult<List<Boundary>>(_boundrayDal.GetList().Where(x => x.IsDeleted == false).ToList());
        }

        public IDataResult<List<Boundary>> GetByStationId(int id)
        {
            var result = _boundrayDal.GetList(x => x.StationID == id && x.IsDeleted == false);
            if (result != null)
            {
                return new SuccessDataResult<List<Boundary>>(result);
            }
            return new ErrorDataResult<List<Boundary>>();
        }

        public IDataResult<Boundary> Update(BoundaryUpdateDto boundary)
        {
            string jwtToken;
            var entity = _boundrayDal.Get(x => x.BoundaryID == boundary.BoundaryID && x.IsDeleted == false);
            entity.Lat = boundary.Lat;
            entity.Long = boundary.Long;
            _boundrayDal.Update(entity);

            try
            {
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

                var entityPost = (HttpWebRequest)WebRequest.Create("https://antalyataksinode.azurewebsites.net/boundaries/" + boundary.BoundaryID);
                entityPost.PreAuthenticate = true;
                entityPost.ContentType = "application/json";
                entityPost.Method = "PATCH";
                entityPost.Headers.Add("Authorization", "Bearer " + jwtToken);
                using (var stream = new StreamWriter(entityPost.GetRequestStream()))
                {
                    string json = "{\"latitude\":\"" + boundary.Lat + "\"," +
                                   "\"longitude\":\"" + boundary.Long +
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
            }
            catch (Exception)
            {
                return new SuccessDataResult<Boundary>(entity);

            }
            return new SuccessDataResult<Boundary>(entity);
        }


    }
}
