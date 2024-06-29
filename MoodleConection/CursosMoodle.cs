using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace MoodleConection
{
    public class CursosMoodle
    {
        private static string moodleUrl = "http://localhost/webservice/rest/server.php";
        private static string token = "44fd8f48a5cbbdf021e843174d3d9b8d";
        public static async Task<Curso> GetCourseByID(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string function = "core_course_get_courses_by_field";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&field=id&value={id}&moodlewsrestformat=json");

                    Curso curso = new Curso();


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();


                        JObject jObject = JObject.Parse(result);

                        JArray jArray = (JArray)jObject["courses"];


                        foreach (var item in jArray)
                        {


                            curso.IdMoodle = (int)item["id"];
                            curso.Nombre = (string)item["fullname"];
                            curso.Visible = (bool)item["visible"];
                            curso.ImagenPortada = (string)item["courseimage"];

                        }
                        return curso;
                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");    
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<List<Curso>> GetCourses()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string function = "core_course_get_courses";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    HttpResponseMessage response = await client.GetAsync($"?wstoken={token}&wsfunction={function}&moodlewsrestformat=json");

                    List<Curso> cursos = new List<Curso>();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        JArray jArray = JArray.Parse(result);

                        foreach (var item in jArray)
                        {
                            Curso curso = new Curso
                            {
                                IdMoodle = (int)item["id"],
                                Nombre = (string)item["fullname"],
                                Visible = (bool)item["visible"],

                            };
                            cursos.Add(curso);
                        }

                        return cursos;


                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<Curso>> GetCourseByStudent(int idMoodle)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string function = "core_enrol_get_users_courses";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "userid", idMoodle.ToString() }
                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    List<Curso> cursos = new List<Curso>();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        JArray jArray = JArray.Parse(result);

                        foreach (var item in jArray)
                        {
                            Curso curso = new Curso
                            {
                                IdMoodle = (int)item["id"],
                                Nombre = (string)item["fullname"],
                                Visible = (bool)item["visible"],
                                //Url = $"{moodleUrl}/course/view.php?id={(int)item["id"]}"
                            };
                            cursos.Add(curso);
                        }

                        return cursos;


                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> VisibleCourse(int idMoodle, int visible)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string function = "core_course_update_courses";

                    client.BaseAddress = new Uri(moodleUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "courses[0][id]", idMoodle.ToString() },
                        { "courses[0][visible]", visible.ToString() }, //1: available to student, 0:not available
                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    HttpResponseMessage response = await client.PostAsync($"/webservice/rest/server.php?wstoken={token}&wsfunction={function}&moodlewsrestformat=json", content);

                    List<Curso> cursos = new List<Curso>();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        // Console.WriteLine(result);
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
