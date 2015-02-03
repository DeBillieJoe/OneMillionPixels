using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                command.CommandText = @"INSERT INTO Pictures (ID, X, Y, Width, Height, Link, Data) Values(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                command.Parameters.AddWithValue("@param1", ID);
                command.Parameters.AddWithValue("@param2", X);
                command.Parameters.AddWithValue("@param3", Y);
                command.Parameters.AddWithValue("@param4", Width);
                command.Parameters.AddWithValue("@param5", Height);
                command.Parameters.AddWithValue("@param6", Link);
                command.Parameters.AddWithValue("@param7", Data);
                command.ExecuteNonQuery();
            }
        }
    }
}