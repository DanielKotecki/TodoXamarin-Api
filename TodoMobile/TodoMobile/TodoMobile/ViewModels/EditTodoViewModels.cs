using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoMobile.Models;
using TodoMobile.Services;
using Xamarin.Forms;

namespace TodoMobile.ViewModels
{
    public class EditTodoViewModels
    {
        ApiServices _apiServices = new ApiServices();
        public TodoDto todoDto { get; set; }

        public ICommand EditCommmand
        {
            get
            {
                return new Command(async () =>
                {
                    var kod = await _apiServices.PutTodoAsync(todoDto);
                    if (kod == System.Net.HttpStatusCode.NoContent)
                    {
                        await Application.Current.MainPage.DisplayAlert("Edit", "Success", "OK");


                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Edit", "Problem!!! Błąd->" + kod, "OK");
                    }
                });
            }
        }

    }
}
