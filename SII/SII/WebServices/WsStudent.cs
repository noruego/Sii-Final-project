using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SII.Models;
using System.Net.Http.Headers;

namespace SII.WebServices
{
    class WsStudent
    {
        public async Task<Student> getStudent()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Settings.ip);
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var resp = await httpClient.GetAsync("/SIIWS_PATM/api/wsstudent/getStudent/" + Settings.idStudent + "/" +Settings.token);

            var json = resp.Content.ReadAsStringAsync().Result;
            Student std = new Student();
            if (json != null)
            {
                std = JsonConvert.DeserializeObject<Student>(json);

                Settings.user_name = std.name + " " + std.father_lastname + " " + std.mother_lastname;
                Settings.user_email = std.email;
                Settings.user_image = std.image;
                Settings.user_num_co = std.nocontrol;
            }
            return std;
        }
    }
}
