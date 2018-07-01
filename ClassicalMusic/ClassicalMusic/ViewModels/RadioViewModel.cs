using ClassicalMusic.Models;
using ClassicalMusic.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using pinoelefante.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClassicalMusic.ViewModels
{
    public class RadioViewModel : MyViewModel
    {
        private PlayerService player;
        public RadioViewModel(INavigationService n, PlayerService ps) : base(n)
        {
            player = ps;
        }
        public MyObservableCollection<RadioItem> RadioList { get; } = new MyObservableCollection<RadioItem>();
        public override async Task NavigatedToAsync(object parameter = null)
        {
            await base.NavigatedToAsync(parameter);
            if (RadioList.Count == 0)
            {
                var radios = AssemblyFileReader.ReadLocalJson<List<RadioItem>>("radio.json");
                Device.BeginInvokeOnMainThread(() =>
                {
                    RadioList.AddRange(radios);
                });
            }
        }
        private RelayCommand<RadioItem> playRadioCmd;
        public RelayCommand<RadioItem> PlayRadioCommand =>
            playRadioCmd ??
            (playRadioCmd = new RelayCommand<RadioItem>((radio) =>
            {
                player.PlayRadio(radio.Name, radio.RadioLink);
            }));
    }
}
