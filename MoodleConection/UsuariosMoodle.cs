using Dominio;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoodleConection
{
    public class UsuariosMoodle
    {
        private static string moodleUrl = "http://localhost/webservice/rest/server.php";
        private static string token = "44fd8f48a5cbbdf021e843174d3d9b8d"; // "44fd8f48a5cbbdf021e843174d3d9b8d"; "b8ea84e7c42a2e8aa2835ab45b7f4683"
        public static async Task<int> CreateUser(Usuario usuario)
        {
            try
            {
                int IdMoodle = -1;

                using (HttpClient client = new HttpClient())
                {
                    string function = "core_user_create_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "users[0][username]", usuario.Email },
                        { "users[0][password]", usuario.Contrasenia },
                        { "users[0][firstname]", usuario.Nombre },
                        { "users[0][lastname]", usuario.Apellido },
                        { "users[0][email]", usuario.Email }
                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        if (result.StartsWith("{\"exception\"")) {
                            return IdMoodle;
                        }

                        JArray jArray = JArray.Parse(result);

                        foreach (var item in jArray)
                        {
                            IdMoodle = (int)item["id"];
                        }

                        return IdMoodle;

                    }
                    else
                    {
                        // Console.WriteLine($"Error: {response.StatusCode}");
                        return IdMoodle;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Get
        public static async Task<Usuario> GetUsersbyID(int id)
        {
            try
            {
                Usuario usuario = new Usuario();

                using (HttpClient client = new HttpClient())
                {


                    string function = "core_user_get_users_by_field";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&field=id&values[0]={id}&moodlewsrestformat=json");




                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        JArray jArray = JArray.Parse(result);

                        foreach (var item in jArray)
                        {
                            usuario.IdMoodle = (int)item["id"];
                            usuario.Nombre = (string)item["firstname"];
                            usuario.Email = (string)item["email"];
                            usuario.Apellido = (string)item["lastname"];
                            usuario.TipoUsuario = TipoUsuario.STUDENT;
                        }
                        return usuario;
                    }
                    else
                    {
                        // Console.WriteLine($"Error: {response.StatusCode}");
                        return null;

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<List<Usuario>> GetUsers()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string function = "core_user_get_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));



                    Dictionary<string, string> postData = new Dictionary<string, string>
                {
                    { "criteria[0][key]", "email" },
                    { "criteria[0][value]", "%@%"}
                };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(result);

                        JArray jArray = (JArray)jObject["users"];

                        foreach (var item in jArray)
                        {
                            Usuario usuario = new Usuario();

                            usuario.IdMoodle = (int)item["id"];
                            usuario.Nombre = (string)item["firstname"];
                            usuario.Email = (string)item["email"];
                            usuario.Apellido = (string)item["lastname"];
                            usuario.TipoUsuario = TipoUsuario.STUDENT;

                            usuarios.Add(usuario);
                        }
                        return usuarios;
                    }
                    else
                    {
                        // Console.WriteLine($"Error: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Delete
        public static async Task<bool> DeleteUsersbyID(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string function = "core_user_delete_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


                    Dictionary<string, string> postData = new Dictionary<string, string>
                {
                     { "userids[0]", id.ToString() }
                };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(result);
                        if (result.StartsWith("{\"exception\""))
                            return false;
                        return true;

                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return false;

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Update
        public static async Task<bool> UpdateUser(Usuario usuario)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string function = "core_user_update_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    Dictionary<string, string> postData = new Dictionary<string, string>
                {
                    { "users[0][id]", usuario.IdMoodle.ToString() },
                    { "users[0][username]", usuario.Email },
                    { "users[0][password]", usuario.Contrasenia },
                    { "users[0][firstname]", usuario.Nombre },
                    { "users[0][lastname]", usuario.Apellido },
                };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(result);
                        if (result.StartsWith("{\"exception\""))
                            return false;
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return false;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static async Task<List<Usuario>> GetStudentsByCourse(int idMoodle)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string function = "core_enrol_get_enrolled_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "courseid", idMoodle.ToString() }
                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        if (result.StartsWith("{\"exception\""))
                            return usuarios;

                        JArray jArray = JArray.Parse(result);

                        foreach (var item in jArray)
                        {
                            Usuario usuario = new Usuario();

                            usuario.IdMoodle = (int)item["id"];
                            usuario.Nombre = (string)item["firstname"];
                            usuario.Email = (string)item["email"];
                            usuario.Apellido = (string)item["lastname"];
                            usuario.TipoUsuario = TipoUsuario.STUDENT;
                            usuarios.Add(usuario);
                        }
                        return usuarios;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> EnrolStudent(int courseId, int userId)
        {
            int roleId = 5;
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string function = "enrol_manual_enrol_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "enrolments[0][roleid]", roleId.ToString() },
                        { "enrolments[0][userid]", userId.ToString() },
                        { "enrolments[0][courseid]", courseId.ToString() }
                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(result);
                        if (result.StartsWith("{\"exception\""))
                        {
                            if (result == "{\"exception\":\"moodle_exception\",\"errorcode\":\"Message was not sent.\",\"message\":\"error\\/Message was not sent.\"}")
                            {
                                return true;
                            }
                            return false;
                        }
                        return true;

                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> UnenrolStudent(int courseId, int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string function = "enrol_manual_unenrol_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "enrolments[0][courseid]", courseId.ToString() },
                        { "enrolments[0][userid]", userId.ToString() }

                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(result);
                        return true;

                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return false;
                    }
                    Console.ReadKey();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> SuspendOrActivateUser(int courseId, int userId, int suspend)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string function = "enrol_manual_enrol_users";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    Dictionary<string, string> postData = new Dictionary<string, string>
                {
                    { "enrolments[0][roleid]", "5" },
                    { "enrolments[0][userid]", userId.ToString() },
                    { "enrolments[0][courseid]", courseId.ToString() },
                    { "enrolments[0][suspend]", suspend.ToString() } // 1 para suspender, 0 para activar
                };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        if (result.StartsWith("{\"exception\""))
                        {
                            if (result == "{\"exception\":\"moodle_exception\",\"errorcode\":\"Message was not sent.\",\"message\":\"error\\/Message was not sent.\"}")
                            {
                                return true;
                            }
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
