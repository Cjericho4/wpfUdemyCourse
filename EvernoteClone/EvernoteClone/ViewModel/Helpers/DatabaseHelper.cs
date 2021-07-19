using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        //Database location
        private static readonly string dbfile = Path.Combine(Environment.CurrentDirectory, "notesDB.db3");

        //Insert to Database
        public static bool Insert<T>(T item)
        {
            bool result = false;

            //Code to actually insert and check that it was succesful.
            using (SQLiteConnection connection = new(dbfile))
            {
                connection.CreateTable<T>();
                int rows = connection.Insert(item);
                if (rows > 0)
                    return true;
            }

            return result;
        }
        //Update Database
        public static bool Update<T>(T item)
        {
            bool result = false;

            //Code to actually insert and check that it was succesful.
            using (SQLiteConnection connection = new(dbfile))
            {
                connection.CreateTable<T>();
                int rows = connection.Update(item);
                if (rows > 0)
                    return true;
            }

            return result;
        }

        //Delete from Database
        public static bool Delete<T>(T item)
        {
            bool result = false;

            //Code to actually insert and check that it was succesful.
            using (SQLiteConnection connection = new(dbfile))
            {
                connection.CreateTable<T>();
                int rows = connection.Delete(item);
                if (rows > 0)
                    return true;
            }

            return result;
        }

        //Read information from the Database.
        public static List<T> Read<T>() where T : new()
        {
            List<T> items;

            //Code to actually insert and check that it was succesful.
            using (SQLiteConnection connection = new(dbfile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }

            return items;
        }
    }
}
