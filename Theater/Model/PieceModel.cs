using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Model
{
    public class PieceModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime? StartTime { get; set; }
        public string Description { get; set; }
    }
}
