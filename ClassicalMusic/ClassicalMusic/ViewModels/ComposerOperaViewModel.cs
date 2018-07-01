using ClassicalMusic.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using pinoelefante.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalMusic.ViewModels
{
    public class ComposerOperaViewModel : MyViewModel
    {
        private Composer composer;
        private Opera opera;

        public ComposerOperaViewModel(INavigationService n) : base(n) { }

        public Composer Composer { get => composer; set => SetMT(ref composer, value); }
        public Opera Opera { get => opera; set => SetMT(ref opera, value); }

        public override async Task NavigatedToAsync(object parameter = null)
        {
            await base.NavigatedToAsync(parameter);
            var tuple = parameter as Tuple<Composer, Opera>;
            Composer = tuple.Item1;
            Opera = tuple.Item2;
        }
        private RelayCommand<Track> playCmd;
        public RelayCommand<Track> PlayItemCommand =>
            playCmd ??
            (playCmd = new RelayCommand<Track>((track) =>
            {

            }));
    }
}
