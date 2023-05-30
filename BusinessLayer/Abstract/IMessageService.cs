using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string userEmail);
        List<Message> GetListSendInbox(string userEmail);
        void MessageAddBL(Message message);
        Message GetByID(int id);

        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
    }
}
