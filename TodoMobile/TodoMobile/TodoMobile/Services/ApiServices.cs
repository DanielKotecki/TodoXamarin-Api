using Android.OS;
using Android.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoMobile.Models;
using TodoMobile.Views;
using Xamarin.Forms;
using Environment = System.Environment;

namespace TodoMobile.Services
{
    public class ApiServices : ContentPage
    {


        public async Task<bool> RegisterAsync(string username, string password)
        {
            var client = new HttpClient();

            var model = new UserForRegisterDto
            {
                Username = username,
                Password = password
            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("https://apimytodo.azurewebsites.net/api/auth/register", content);
            //client.Timeout = TimeSpan.FromMinutes(30);
            return response.IsSuccessStatusCode;
        }
        public async Task<System.Net.HttpStatusCode> LoginAsync(string userName, string password)
        {


            var client = new HttpClient();

            var model = new UserForLoginDto
            {
                Username = userName,
                Password = password
            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("https://apimytodo.azurewebsites.net/api/auth/login", content);
            //client.Timeout = TimeSpan.FromMinutes(30);
            var zwracane = await response.Content.ReadAsStringAsync();

            var z = JsonConvert.DeserializeObject<TokenDto>(zwracane);

            Console.WriteLine("$$[" + z.token + "]$$");

            Console.WriteLine("$$[kod" + response.StatusCode.ToString() + "]$$");

            if (z.token == "")
            {
                await DisplayAlert("Tytuł", "Złe dane", "OK");
            }
            else
            {
                Token.ApiToken = z.token;
                // await Navigation.PushAsync(new LoginPage
                //{
                //  BindingContext = new TodoPage()
                //});
                Console.WriteLine("Token!!!" + Token.ApiToken);

            }
            return response.StatusCode;

        }



        public async Task<List<TodoDto>> GetTodoAsync()
        {
            Console.WriteLine("Token Get" + Token.ApiToken);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token.ApiToken);
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = await client.GetStringAsync("https://apimytodo.azurewebsites.net/api/todo");

            var todo = JsonConvert.DeserializeObject<List<TodoDto>>(json);
            Console.WriteLine(todo);
            return todo;
        }

        public async Task PostTodoAsync(TodoDto todoDto)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token.ApiToken);

            var json = JsonConvert.SerializeObject(todoDto);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("https://apimytodo.azurewebsites.net/api/todo", content);

        }

        public async Task<System.Net.HttpStatusCode> PutTodoAsync(TodoDto todoDto)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token.ApiToken);

            var json = JsonConvert.SerializeObject(todoDto);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync("https://apimytodo.azurewebsites.net/api/todo/" + todoDto.Id, content);
            return response.StatusCode;
        }
    }
}
