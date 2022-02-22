using MafiaConsole.Models;
using MafiaConsole.Services;
using System;

namespace MafiaConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            PieceDAO pieceDAO = new PieceDAO();

            foreach (PieceModel p in pieceDAO.GetAllPieces())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            
            Console.WriteLine("Welcome, would you like to create, read, update, or delete pieces?");
            String answer = Console.ReadLine().ToLower();
            if (answer.Equals("create"))
            {
                PieceModel pieceModel1 = new PieceModel();
                
                Console.WriteLine("Enter the piece name:");
                String uName = Console.ReadLine();
                pieceModel1.Name = uName;

                Console.WriteLine("Enter the composer:");
                String uComposer = Console.ReadLine();
                pieceModel1.Composer = uComposer;

                Console.WriteLine("Enter the period:");
                String uPeriod = Console.ReadLine();
                pieceModel1.Period = uPeriod;

                Console.WriteLine("Enter the tempo:");
                int uTempo = Convert.ToInt32(Console.ReadLine());
                pieceModel1.Tempo = uTempo;

                Console.WriteLine("Enter the time signature:");
                String uTimeSignature = Console.ReadLine();
                pieceModel1.TimeSignature = uTimeSignature;

                pieceDAO.Insert(pieceModel1);
            }
            else if (answer.Equals("read"))
            {
                Console.WriteLine("What field would you like to search by?");
                String answer3 = Console.ReadLine().ToLower();
                if (answer3.Equals("name"))
                {
                    Console.WriteLine("Enter a piece name to search for:");

                    String input = Console.ReadLine();
                    Console.WriteLine(pieceDAO.GetPiece(input));
                }
                else if (answer3.Equals("id"))
                {
                    Console.WriteLine("Enter an id to search for:");

                    int id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(pieceDAO.GetPiece(id)); 
                }
                else
                {
                    Console.WriteLine("Error encountered, exiting program.");
                    return;
                }
            }
            else if (answer.Equals("update"))
            {
                Console.WriteLine("Enter piece id to update:");

                int id = Int32.Parse(Console.ReadLine());

                PieceModel piece = GetPiece();
                piece.Id = id;

                pieceDAO.Update(piece);
            }
            else if (answer.Equals("delete"))
            {
                Console.WriteLine("What field would you like to delete by?");
                String answer4 = Console.ReadLine().ToLower();
                if (answer4.Equals("id"))
                {
                    Console.WriteLine("Enter an id to delete:");

                    int id = Int32.Parse(Console.ReadLine());
                    pieceDAO.Delete(id);
                }
                else if (answer4.Equals("name"))
                {
                    Console.WriteLine("Enter a piece name to delete:");

                    int id = Int32.Parse(Console.ReadLine());
                    PieceModel piece = pieceDAO.GetPiece(id);
                    pieceDAO.Delete(piece);
                }
                else
                {
                    Console.WriteLine("Error encountered, exiting program.");
                    return;
                }
            }
            else 
            {
                Console.WriteLine("Exiting program.");
                return;
            } 
            
            
            
            foreach (PieceModel p in pieceDAO.GetAllPieces())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            /* Console.WriteLine("Enter an id to delete:");

            int id = Int32.Parse(Console.ReadLine());
            pieceDAO.Delete(id); */

            /*Console.WriteLine("Enter name to delete:");

            string pName = Console.ReadLine();
            PieceModel piece2 = new PieceModel();
            piece2.Name = pName;
            pieceDao.Delete(piece2);*/

            /*
            Console.WriteLine("Enter piece id to update:");
            
            int id = Int32.Parse(Console.ReadLine());

            PieceModel piece = GetPiece();
            piece.Id = id;

            pieceDAO.Update(piece);
            */


            



        }

        public static PieceModel GetPiece()
        {
            PieceModel piece = new PieceModel();

            Console.WriteLine("Enter Piece Name:");
            piece.Name = Console.ReadLine();
            Console.WriteLine("Enter Composer:");
            piece.Composer = Console.ReadLine();
            Console.WriteLine("Enter Period:");
            piece.Period = Console.ReadLine();
            Console.WriteLine("Enter Tempo:");
            piece.Tempo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Time Signature:");
            piece.TimeSignature = Console.ReadLine();
            

            return piece;
        }

        public static void AddPiece()
        {
            PieceDAO pieceN = new PieceDAO();
            
            pieceN.Insert(GetPiece());
        }
    }
}
