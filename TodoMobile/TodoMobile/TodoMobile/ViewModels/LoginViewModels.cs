using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TodoMobile.Services;
using TodoMobile.Views;
using Xamarin.Forms;

namespace TodoMobile.ViewModels
{
    public class LoginViewModels : ContentPage
    {
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
{
    var kod = await _apiServices.LoginAsync(Username, Password);
    if (kod ==
System.Net.HttpStatusCode.OK)
    {
        //await Application.Current.MainPage.DisplayAlert("Login", "Success", "OK");
        await Application.Current.MainPage.Navigation.PushAsync(new TodoPage());

    }
    else
    {
        await Application.Current.MainPage.DisplayAlert("Login", "Problem!!!", "OK");
    }
});
            }
        }
    }
}
