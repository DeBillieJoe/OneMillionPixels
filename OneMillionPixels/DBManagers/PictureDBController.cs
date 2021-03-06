﻿using Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DBManagers
{
    public class PictureDBController : DBControllerBase
    {
        public void Save(Picture obj)
        {
            if (string.IsNullOrEmpty(obj.User))
                throw new Exception("You are not logged in.");

            if (string.IsNullOrEmpty(obj.ID))
                obj.ID = System.Guid.NewGuid().ToString("N");

            var command = this.CreateCommand();
            command.CommandText = @"UPDATE Pictures SET Data = @param1, Link = @param2, ContentType = @param5 WHERE ID = @param3 AND Username = @param4";
            command.Parameters.Add("@param1", SqlDbType.Image).Value = obj.Data;
            command.Parameters.Add("@param2", SqlDbType.NText).Value = obj.Link;
            command.Parameters.Add("@param3", SqlDbType.NVarChar).Value = obj.ID;
            command.Parameters.Add("@param4", SqlDbType.NVarChar).Value = obj.User;
            command.Parameters.Add("@param5", SqlDbType.NVarChar).Value = obj.ContentType;

            int rowsEffected = command.ExecuteNonQuery();

            if (rowsEffected == 0)
                throw new Exception("There is no such image owned by you.");
        }

        public void SaveNew(Picture obj)
        {
            if (string.IsNullOrEmpty(obj.User))
                throw new Exception("You are not logged in.");

            if (string.IsNullOrEmpty(obj.ID))
                obj.ID = System.Guid.NewGuid().ToString("N");

            var command = this.CreateCommand();
            command.CommandText = @"INSERT INTO Pictures (ID, X, Y, Width, Height, Link, Data, Username, ContentType) 
                                        (SELECT @param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9
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
            command.Parameters.Add("@param9", SqlDbType.NVarChar).Value = obj.ContentType;


            int rowsEffected = command.ExecuteNonQuery();

            if (rowsEffected == 0)
                    throw new Exception("This place is already taken.");
        }

        public List<Picture> RetrieveAll()
        {
            return RetrieveAll(string.Empty);
        }
        public List<Picture> RetrieveAll(string user)
        {
            List<Picture> pictures = new List<Picture>();

            var command = this.CreateCommand();
            command.CommandText = @"SELECT ID, X, Y, Width, Height, Link, Data, Username, ContentType FROM Pictures";

            if (!string.IsNullOrEmpty(user))
            {
                command.CommandText += " WHERE Username = @param1";
                command.Parameters.Add("@param1", SqlDbType.NVarChar).Value = user;
            }

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
                picture.ContentType = (string)reader["ContentType"];
                pictures.Add(picture);
            }

            return pictures;
        }
    }
}
