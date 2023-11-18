using Newtonsoft.Json;
using Protecto_MVC.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Protecto_MVC.API
{
    public class UserAPI
    {

        public async Task<List<User>> GetUsersRequest()
        {
            String result = string.Empty;

            try
            {
                string url = "https://localhost:7023/User/";
                string api = "GetUsers";
                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(api);
                    result = response.Content.ReadAsStringAsync().Result;

                }
            }
            catch (Exception e)
            {
                return null;
            }
            if (result.Contains("HTTP ERROR 500"))
            {
                return null;
            }
            List<User> oUsers = new List<User>();
            oUsers = (List<User>)JsonConvert.DeserializeObject(result, typeof(List<User>));
            return oUsers;
        }

        public async Task<User> CreateUser(User newUser)
        {
            try
            {
                string url = "https://localhost:7023/User/CreateUser";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Serializar el objeto newUser a formato JSON
                    var json = JsonConvert.SerializeObject(newUser);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    // Realizar la solicitud POST para crear un nuevo usuario
                    HttpResponseMessage response = await client.PostAsync(url, data);
                   

                    // Verificar si la solicitud fue exitosa (código de estado 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer y deserializar la respuesta JSON a un objeto User
                        string responseData = await response.Content.ReadAsStringAsync();
                        User createdUser = JsonConvert.DeserializeObject<User>(responseData);
                        return createdUser;
                    }
                    else
                    {
                        // Manejar errores si la solicitud no fue exitosa
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
                return null;
            }
        }

        public async Task<bool> DeleteUser(string usernameToDelete)
        {
            try
            {
                string url = $"https://localhost:7023/User/DeleteUser?username={usernameToDelete}";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Realizar la solicitud DELETE para eliminar el usuario
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    Debug.WriteLine("==============Mensaje============");
                    Debug.WriteLine($"URL:{url}");
                    Debug.WriteLine($"Data: {response}"); // Reemplaza 'Nombre' con el nombre del atributo que quieras imprimir

                    // Verificar si la solicitud fue exitosa (código de estado 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // El usuario fue eliminado exitosamente
                        return true;
                    }
                    else
                    {
                        // Manejar errores si la solicitud no fue exitosa
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
                return false;
            }
        }
    }
}




