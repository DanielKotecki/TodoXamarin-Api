using Android.Content.Res;
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
    public partial class TodoPage : ContentPage
    {
        public TodoPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTodoPage());
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var zmiena = e.Item as TodoDto;
            await Navigation.PushAsync(new EditPage(zmiena));
        }


    }
}