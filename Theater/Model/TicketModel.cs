using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Model
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string NamePiece { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public DateTime? Birthday { get; set; }
        public double Price { get; set; }
    }
}
