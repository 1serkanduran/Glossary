using BusinessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;
        public MessageManager(IMessageDal messageDal)
        {
            _messagedal = messageDal;
        }
        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListDraft(string userEmail)
        {
           return _messagedal.List(x=>x.IsDraft==true && x.SenderMail == userEmail);
        }

        public List<Message> GetListInbox(string userEmail)
        {
            return _messagedal.List(x => x.ReceiverMail == userEmail);
        }

        public List<Message> GetListSendInbox(string userEmail)
        {
            return _messagedal.List(x => x.SenderMail == userEmail);
        }

        public List<Message> IsDraft(string userEmail)
        {
            return _messagedal.List(x=>x.IsDraft==true && x.SenderMail == userEmail);
        }

        public void MessageAddBL(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDeleteBL(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdateBL(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
