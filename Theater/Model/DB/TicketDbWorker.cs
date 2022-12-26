using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Model.DB
{
    class TicketDbWorker
    {
        static ApplicationContext db = new ApplicationContext();

        public TicketModel[] GetAllTicket()
        {
            return db.Ticket.ToArray();
        }
        public void CreateNewTicket(TicketModel ticket)
        {
            bool userExist = db.Ticket.Any(t => t.Id == ticket.Id);
            if (!userExist)
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
            }
        }
        public void DeleteTicket(TicketModel ticket)
        {
            bool userExist = db.Ticket.Any(t => t.Id == ticket.Id);
            if (userExist)
            {
                db.Ticket.Remove(ticket);
                db.SaveChanges();
            }
        }
    }
}
