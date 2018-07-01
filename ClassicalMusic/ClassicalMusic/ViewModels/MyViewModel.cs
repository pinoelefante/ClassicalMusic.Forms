using ClassicalMusic.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using pinoelefante.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pinoelefante.ViewModels
{
    public class MyViewModel : ViewModelBase
    {
        protected static MyObservableCollection<Composer> ComposerList = new MyObservableCollection<Composer>();

        public NavigationService Navigation { get; private set; }
        
        public MyViewModel(INavigationService n)
        {
            Navigation = n as NavigationService;
        }
        private bool busyActive;
        private string busyMsg;
        public bool IsBusyActive { get => busyActive; set => SetMT(ref busyActive, value); }
        public string BusyMessage { get => busyMsg; set => SetMT(ref busyMsg, value); }
        
        public void SetBusy(bool status, string text)
        {
            BusyMessage = text;
            IsBusyActive = status;
        }
        public virtual Task NavigatedToAsync(object parameter = null)
        {
            RegisterMessenger();
            return Task.CompletedTask;   
        }
        public virtual void RegisterMessenger() { }
        public virtual void NavigatedFrom() { }
        /*
         * OnBackPressed() must return true when override 
         */
        public virtual bool OnBackPressed()
        {
            Navigation.GoBack();
            return true;
        }
        public void SetMT<T>(ref T field, T value, [CallerMemberName]string fieldName="")
        {
            var old_value = field;
            field = value;
            Device.BeginInvokeOnMainThread(() =>
            {
                RaisePropertyChanged(fieldName, old_value, value);
            });
        }
    }
}
