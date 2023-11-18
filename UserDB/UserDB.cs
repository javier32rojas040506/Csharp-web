using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json; // Asegúrate de tener instalado Newtonsoft.Json a través de NuGet
using UserDomain;

namespace UserDB
{
    public class UserDB
    {
        private static UserDB instance;
        private List<User> users;
        private string filePath = "users.txt"; // Nombre del archivo donde se guardarán los usuarios

        private UserDB()
        {
            users = new List<User>();
            LoadUsersFromFile(); // Cargar usuarios desde el archivo al crear una nueva instancia
        }

        // Método estático para obtener la única instancia de UserDB
        public static UserDB GetInstance()
        {
            if (instance == null)
            {
                instance = new UserDB();
            }
            return instance;
        }

        public void AddUser(User user)
        {
            users.Add(user);
            SaveUsersToFile(); // Guardar usuarios en el archivo después de agregar uno nuevo
        }

        public List<User> GetAllUsers()
        {
            LoadUsersFromFile();
            return users;
        }

        private void SaveUsersToFile()
        {
            string json = JsonConvert.SerializeObject(users); // Convertir la lista de usuarios a formato JSON
            File.WriteAllText(filePath, json); // Escribir el JSON en el archivo
        }

        private void LoadUsersFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath); // Leer el contenido del archivo
                if (!string.IsNullOrEmpty(json))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(json); // Convertir el JSON a lista de usuarios
                }
                else {
                    users = new List<User>();
                }
            }
            else {
                users = new List<User>();
            }
        }

        public bool deleteUserByUsername(String usernameToDelete)
        {
            User userToRemove = users.FirstOrDefault(user => user.UserName == usernameToDelete);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                SaveUsersToFile();
                return true;
            }
            return false;
        }
    }
}
