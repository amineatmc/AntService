using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ScoreManager : IScoreService
    {
        IScoreDal _scoreDal;
        public ScoreManager(IScoreDal scoreDal)
        {
            _scoreDal = scoreDal;
        }

        public IResult Add(Score score)
        {
            score.CreatedDate= DateTime.Now;
            _scoreDal.Add(score);
            return new SuccessResult();
        }

        public IDataResult<Score> GetByDriverId(int id)
        {
            var scores = new List<Score>();
            var list = _scoreDal.GetList().Where(x => x.DriverId == id).ToList();
            int total = 0;
            for (int i = 0; i < list.Count; i++)
            {
                 total += list[i].Point;
            }
            total= total / list.Count;
            var data =_scoreDal.GetList().Where(x=>x.DriverId== id).FirstOrDefault();
            data.DriverId = id;
            data.Point = total;            
            return new SuccessDataResult<Score>(data);

        }
    }
}
