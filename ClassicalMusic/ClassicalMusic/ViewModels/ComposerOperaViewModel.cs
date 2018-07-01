using ClassicalMusic.Models;
using ClassicalMusic.Services;
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
        private PlayerService player;
        public ComposerOperaViewModel(INavigationService n, PlayerService ps) : base(n)
        {
            player = ps;
        }

        public Composer Composer { get => composer; set => SetMT(ref composer, value); }
        public Opera Opera { get => opera; set => SetMT(ref opera, value); }

        public override async Task NavigatedToAsync(object parameter = null)
        {
            await base.NavigatedToAsync(parameter);
            var tuple = parameter as Tuple<Composer, Opera>;
            Composer = tuple.Item1;
            Opera = tuple.Item2;
        }
        private RelayCommand playAllCmd;
        private RelayCommand<Track> playCmd;
        public RelayCommand<Track> PlayItemCommand =>
            playCmd ??
            (playCmd = new RelayCommand<Track>((track) =>
            {
                var index = Opera.Tracks.IndexOf(track);
                player.PlayOperaFromIndex(Composer, Opera, index);
            }));
        public RelayCommand PlayAllCommand =>
            playAllCmd ??
            (playAllCmd = new RelayCommand(() =>
            {
                player.PlayOpera(Composer, Opera);
            }));
    }
}
