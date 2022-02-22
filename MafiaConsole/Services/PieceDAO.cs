using MafiaConsole.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Services
{
    public class PieceDAO
    {
        public int Insert(PieceModel piece)
        {
            int newIdNumber = -1;
            string sqlStatement = @"INSERT INTO dbo.Pieces (Name, Composer, Period, Tempo, TimeSignature) VALUES (@Name, @Composer, @Period, @Tempo, @TimeSignature); ";

            using (SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", piece.Name);
                command.Parameters.AddWithValue("@Composer", piece.Composer);
                command.Parameters.AddWithValue("@Period", piece.Period);
                command.Parameters.AddWithValue("@Tempo", piece.Tempo);
                command.Parameters.AddWithValue("@TimeSignature", piece.TimeSignature);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public List<PieceModel> GetAllPieces()
        {
            List<PieceModel> piece = new List<PieceModel>();
            string sqlStatement = "SELECT * FROM dbo.Pieces";

            using (SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader[0];

                        string name = (string)reader[1];
                        name = name.Trim();

                        string composer = (string)reader[2];
                        composer = composer.Trim();

                        string period = (string)reader[3];
                        period = period.Trim();

                        int tempo = (int)reader[4];

                        string timeSignature = (string)reader[5];
                        timeSignature = timeSignature.Trim();

                        piece.Add(new PieceModel
                        {
                            Id = id,
                            Name = name,
                            Composer = composer,
                            Period = period,
                            Tempo = tempo,
                            TimeSignature = timeSignature
                        }
                        );
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return piece;
        }

        public PieceModel GetPiece(string pName)
        {
            string sqlStatement = "SELECT * FROM dbo.Pieces WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", pName);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader[0];

                        string name = (string)reader[1];
                        name = name.Trim();

                        string composer = (string)reader[2];
                        composer = composer.Trim();

                        string period = (string)reader[3];
                        period = period.Trim();

                        int tempo = (int)reader[4];

                        string timeSignature = (string)reader[5];
                        timeSignature = timeSignature.Trim();

                        PieceModel piece = new PieceModel()
                        {
                            Id = id,
                            Name = name,
                            Composer = composer,
                            Period = period,
                            Tempo = tempo,
                            TimeSignature = timeSignature
                        };
                        return piece;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public PieceModel GetPiece(int ID)
        {
            string sqlStatement = "SELECT * FROM dbo.Pieces WHERE ID = @Id";

            using(SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader[0];

                        string name = (string)reader[1];
                        name = name.Trim();

                        string composer = (string)reader[2];
                        composer = composer.Trim();

                        string period = (string)reader[3];
                        period = period.Trim();

                        int tempo = (int)reader[4];

                        string timeSignature = (string)reader[5];
                        timeSignature = timeSignature.Trim();

                        PieceModel piece = new PieceModel()
                        {
                            Id = id,
                            Name = name,
                            Composer = composer,
                            Period = period,
                            Tempo = tempo,
                            TimeSignature = timeSignature
                        };
                        return piece;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public int Update(PieceModel piece)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE dbo.Pieces SET Name = @Name, Composer = @Composer, Period = @Period, Tempo = @Tempo, TimeSignature = @TimeSignature WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", piece.Name);
                command.Parameters.AddWithValue("@Composer", piece.Composer);
                command.Parameters.AddWithValue("@Period", piece.Period);
                command.Parameters.AddWithValue("@Tempo", piece.Tempo);
                command.Parameters.AddWithValue("@TimeSignature", piece.TimeSignature);
                command.Parameters.AddWithValue("@Id", piece.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;

            }
        }

        public int Delete(PieceModel piece)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Pieces WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", piece.Name);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;
            }
        }
        
        public int Delete(int id)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Pieces WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(Connection.sqlConnection()))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;
            }
        }
    }
}
