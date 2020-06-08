using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoMobile.Models;
using TodoMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TodoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage(TodoDto todoDto)
        {
            var editviewmodel = new EditTodoViewModels();
            editviewmodel.todoDto = todoDto;
            BindingContext = editviewmodel;
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
            await Navigation.PushAsync(new TodoPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Title: " + Title.Text + " Description: " + Description.Text,
                Title = "Share Text"
            });
        }
    }
}