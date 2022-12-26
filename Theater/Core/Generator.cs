using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.Model;

namespace Theater.Core
{
    class Generator
    {
        private static List<string> FIO = new List<string>()
        {
            "Олег",
            "Иван",
            "Пётр",
            "Владислав",
            "Дмитрий",
            "Егор",
            "Павел",
            "Станислав",
            "Андрей",
            "Илья"
        };

        private static List<string> Login = new List<string>()
        {
            "Janiam",
            "Velie",
            "Kaidarc",
            "Neyann",
            "Winowar",
            "Oryde",
            "Merician"
        };

        private static List<string> Password = new List<string>()
        {
            "I9bpc5",
            "ZJf98C",
            "GSdasDFDf324",
            "dsadsa342a",
            "dsad342asdasd3",
            "gdfsk5342a",
            "8054389fkdskopfds"
        };


        private static List<string> Adress = new List<string>()
        {
            "adress1",
            "adress2",
            "adress3",
            "adress4",
            "adress5",
            "adress6",
            "adress7"
        };



        private static List<string> NamePiece = new List<string>()
        {
            "Ревизор",
            "Гроза",
            "Горе от ума",
            "На дне",
            "Недоросль",
            "Вишневый сад"
        };


        private static List<string> Description = new List<string>()
        {
            "Description1",
            "Description2",
            "Description3",
            "Description4",
            "Description5",
            "Description6"
        };


        private static double GeneratePrice()
        {
            double temp = new Random().Next(800, 1500);
            return temp;
        }

        private static long GenerateNumber()
        {
            string temp = "89" + (new Random().Next(99999999, 1000000000));
            return Convert.ToInt64(temp);
        }

        public static void GenerateClient(int val)
        {
            for (int i = 0; i < val; i++)
            {
                UserModel cModel = new UserModel()
                {
                    Login = Login[new Random().Next(Login.Count)],
                    Password = Password[new Random().Next(Password.Count)],
                    FullName = FIO[new Random().Next(FIO.Count)],
                    PhoneNumber = GenerateNumber().ToString(),
                    Birthday = DateTime.Now,
                    Adress = Adress[new Random().Next(Adress.Count)],
                    IsAdmin = false
                };
                new Model.DB.UserDbWorker().CreateNewUser(cModel);
            }
        }


        public static void GeneratePiece(int val)
        {
            for (int i = 0; i < val; i++)
            {
                PieceModel cModel = new PieceModel()
                {
                    Price = GeneratePrice(),
                    Name = NamePiece[new Random().Next(NamePiece.Count)],
                    AuthorName = FIO[new Random().Next(FIO.Count)],
                    Description = Description[new Random().Next(Description.Count)],
                    StartTime = DateTime.Now
                };
                new Model.DB.PieceDbWorker().CreateNewPiece(cModel);
            }
        }


        public static void GenerateTicket(int val)
        {
            for (int i = 0; i < val; i++)
            {
                TicketModel cModel = new TicketModel()
                {
                    NamePiece = NamePiece[new Random().Next(NamePiece.Count)],
                    Description = Description[new Random().Next(Description.Count)],
                    AuthorName = FIO[new Random().Next(FIO.Count)],
                    Birthday = DateTime.Now,
                    Price = GeneratePrice()
                };
                new Model.DB.TicketDbWorker().CreateNewTicket(cModel);
            }
        }



    }
}