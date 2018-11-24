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
    class WsLogin
    {
        private Student student;
        private WsStudent objWsStu;

        public async Task<String> conexion(String user, String pwd)
        {
            Settings.ip = "http://192.168.1.98:8080";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Settings.ip);
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var resp = await httpClient.GetAsync("/SIIWS_PATM/api/wsuser/validate/" + user + "/" + pwd);
            var json = resp.Content.ReadAsStringAsync().Result;
            Login login = new Login();
            if (json != null)
            {
                login = JsonConvert.DeserializeObject<Login>(json);
                Settings.token = login.token;
                Settings.idStudent = login.idestudent;
                /*
                student = await objWsStu.getStudent();
                Settings.user_name=student.name+" "+student.father_lastname + " "+student.mother_lastname;
                Settings.user_email = student.email;
                Settings.user_image = student.image;
                Settings.user_num_co = student.nocontrol;*/

            }
            return login.token;
        }
    }
}
