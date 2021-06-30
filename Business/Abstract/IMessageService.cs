using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetSendInbox(string p);
        List<Message> GetAll();
        Message Get(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
    }
}
