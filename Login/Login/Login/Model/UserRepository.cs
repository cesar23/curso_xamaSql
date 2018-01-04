using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Login.Model
{
    public class UserRepository
    {
        private SQLiteConnection con;

        private static UserRepository instancia;

        public static UserRepository Instancia
        {
            get
            {
                return instancia;
            }
        }

        public static  void Inicializador(String filename)
        {
            if (filename == null)
                throw new ArgumentNullException();


            if (instancia != null)
                instancia.con.Close();

            instancia = new UserRepository(filename);
        }


        private UserRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>();
        }
        public String EstadoMensaje;

        public int AddNewUser(string username, string email, string password)
        {
            int result = 0;

            try
            {
                result = con.Insert(new User()
                {
                    Username = username,
                    Email = email,
                    Password = password
                });

                EstadoMensaje = string.Format("Cantidad e filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public IEnumerable<User> GetAllUser()
        {
            try
            {
                return con.Table<User>();
            }
            catch(Exception e)
            {
                EstadoMensaje = e.Message;

            }
           
            return Enumerable.Empty<User>();
        }


    }
}
