using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoMobile.Services;
using Xamarin.Forms;

namespace TodoMobile.ViewModels
{
    public class RegisterViewModels : ContentPage
    {
        ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Username, Password);
                    if (isSuccess)
                    {
                        await Application.Current.MainPage.DisplayAlert("Register", "Success", "OK");
                    }
                    else { await Application.Current.MainPage.DisplayAlert("Register Problem", "User exists!", "OK"); }

                });
            }
        }
    }
}
