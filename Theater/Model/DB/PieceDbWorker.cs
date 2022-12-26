using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Model.DB
{
    public class PieceDbWorker
    {
        static ApplicationContext db = new ApplicationContext();

        public PieceModel[] GetAllPieces()
        {
            return db.Pieces.ToArray();
        }
        public void CreateNewPiece(PieceModel piece)
        {
            bool userExist = db.Pieces.Any(p => p.Id == piece.Id);
            if (!userExist)
            {
                db.Pieces.Add(piece);
                db.SaveChanges();
            }
        }
        public void DeletePiece(PieceModel piece)
        {
            bool userExist = db.Pieces.Any(p => p.Id == piece.Id);
            if (userExist)
            {
                db.Pieces.Remove(piece);
                db.SaveChanges();
            }
        }
    }
}
