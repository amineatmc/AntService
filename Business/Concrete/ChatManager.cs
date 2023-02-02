using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ChatManager : IChatService
    {
        IChatDal _chatDal;
        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }

        public async Task<IResult> Add(Chat entity)
        {
            entity.CreatedDate= DateTime.Now;
            _chatDal.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Chat>> GetByRequestId(string id)
        {
            return new SuccessDataResult<List<Chat>>(_chatDal.GetList().Where(x=>x.RequestId==id).ToList());
        }
    }
}
