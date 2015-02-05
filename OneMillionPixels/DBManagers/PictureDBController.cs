using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagers
{
    public class PictureDBController : DBControllerBase
    {
        public PictureDBController() : base()
        {

        }
        public void SaveNew(Picture obj)
        {
            if (string.IsNullOrEmpty(obj.ID))
                obj.ID = System.Guid.NewGuid().ToString("N");

            using (this)
            {
                var command = this.CreateCommand();
                command.CommandText = @"INSERT INTO Pictures (ID, X, Y, Width, Height, Link, Data, Username) 
                                            (SELECT @param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8
                                            WHERE NOT EXISTS
                                                (SELECT TOP 1 1 FROM Pictures 
                                                WHERE NOT(X + Width < @param2 OR @param2 + @param4 < X OR Y + Height < @param3 OR @param3 + @param5 < Y)))";
                command.Parameters.Add("@param1", SqlDbType.NVarChar).Value = obj.ID;
                command.Parameters.Add("@param2", SqlDbType.Int).Value = obj.X;
                command.Parameters.Add("@param3", SqlDbType.Int).Value = obj.Y;
                command.Parameters.Add("@param4", SqlDbType.Int).Value = obj. Width;
                command.Parameters.Add("@param5", SqlDbType.Int).Value = obj.Height;
                command.Parameters.Add("@param6", SqlDbType.NText).Value = obj.Link;
                command.Parameters.Add("@param7", SqlDbType.Image).Value = obj.Data;
                command.Parameters.Add("@param8", SqlDbType.NVarChar).Value = obj.User;


                int rowsEffected = command.ExecuteNonQuery();

                if (rowsEffected == 0)
                    throw new Exception("This place is already taken.");
            }
        }

        public List<Picture> RetrieveAll()
        {
            List<Picture> pictures = new List<Picture>();

            using (this)
            {
                var command = this.CreateCommand();
                command.CommandText = @"SELECT ID, X, Y, Width, Height, Link, Data, Username FROM Pictures";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Picture picture = new Picture();

                    picture.ID = (string)reader["ID"];
                    picture.X = (int)reader["X"];
                    picture.Y = (int)reader["Y"];
                    picture.Width = (int)reader["Width"];
                    picture.Height = (int)reader["Height"];
                    picture.Link = (string)reader["Link"];
                    picture.Data = (byte[])reader["Data"];
                    picture.User = (string)reader["Username"];
                    pictures.Add(picture);
                }
            }

            return pictures;
        }
    }
}
