using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public int UnIsRead()
        {
            var total = _messageDal.GetAll(c => c.IsRead == false && c.ReceiverMail == "admin@gmail.com").Count();
            return total;
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public Message Get(int id)
        {
            return _messageDal.Get(c => c.MessageId == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.GetAll(c => c.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetSendInbox()
        {
            return _messageDal.GetAll(c => c.SenderMail == "admin@gmail.com");
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
