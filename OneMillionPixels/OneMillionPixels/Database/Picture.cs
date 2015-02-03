using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace OneMillionPixels.Database
{
    public class Picture
    {
        public string ID { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Link { get; set; }
        public byte[] Data { get; set; }

        public Picture()
        {
            ID = System.Guid.NewGuid().ToString("N");
        }

        public void SaveNew()
        {
            using (DBController dbu = new DBController())
            {
                var command = dbu.CreateCommand();
                command.CommandText = @"INSERT INTO Pictures (ID, X, Y, Width, Height, Link, Data) 
                                            (SELECT @param1, @param2, @param3, @param4, @param5, @param6, @param7
                                            WHERE NOT EXISTS
                                                (SELECT TOP 1 1 FROM Pictures 
                                                WHERE NOT(X + Width < @param2 OR @param2 + @param4 < X OR Y + Height < @param3 OR @param3 + @param5 < Y)))";
                command.Parameters.Add("@param1", SqlDbType.NVarChar).Value = ID;
                command.Parameters.Add("@param2", SqlDbType.Int).Value = X;
                command.Parameters.Add("@param3", SqlDbType.Int).Value = Y;
                command.Parameters.Add("@param4", SqlDbType.Int).Value = Width;
                command.Parameters.Add("@param5", SqlDbType.Int).Value = Height;
                command.Parameters.Add("@param6", SqlDbType.NText).Value = Link;
                command.Parameters.Add("@param7", SqlDbType.Image).Value = Data;


                int rowsEffected = command.ExecuteNonQuery();

                if (rowsEffected == 0)
                    throw new Exception("This place is already taken.");
            }
        }
    }
}