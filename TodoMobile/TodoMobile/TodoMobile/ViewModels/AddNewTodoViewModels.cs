using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoMobile.Models;
using TodoMobile.Services;
using Xamarin.Forms;

namespace TodoMobile.ViewModels
{
    public class AddNewTodoViewModels
    {
        ApiServices _apiServices = new ApiServices();
        public string Title { get; set; }
        public string Description { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {

                    var todoDto = new TodoDto
                    {
                        Title = Title,
                        Description = Description
                    };
                    await _apiServices.PostTodoAsync(todoDto);

                });
            }
        }
    }
}
