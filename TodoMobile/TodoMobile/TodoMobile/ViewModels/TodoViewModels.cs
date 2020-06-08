using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TodoMobile.Models;
using TodoMobile.Services;
using Xamarin.Forms;

namespace TodoMobile.ViewModels
{
    public class TodoViewModels : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<TodoDto> _todos;

        public List<TodoDto> todoDtos //{ get; set; }
        {
            get { return _todos; }
            set
            {
                _todos = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetTodoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    todoDtos = await _apiServices.GetTodoAsync();
                });
            }
        }

        //   public List<TodoDto> _todos { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
