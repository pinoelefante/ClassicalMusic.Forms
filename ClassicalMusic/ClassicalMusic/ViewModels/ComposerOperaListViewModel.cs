using ClassicalMusic.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using pinoelefante.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalMusic.ViewModels
{
    public class ComposerOperaListViewModel : MyViewModel
    {
        private Composer composer;

        public ComposerOperaListViewModel(INavigationService n) : base(n)
        {
        }
        public Composer Composer { get => composer; set => SetMT(ref composer, value); }
        public MyObservableCollection<Opera> OperaList { get; } = new MyObservableCollection<Opera>();
        public override Task NavigatedToAsync(object parameter = null)
        {
            OperaList.Clear();
            if(parameter is Tuple<Composer, Category>)
            {
                var cc = parameter as Tuple<Composer, Category>;
                Composer = cc.Item1;
                OperaList.AddRange(cc.Item2.OperaList);
            }
            else if(parameter is Composer)
            {
                Composer = parameter as Composer;
                OperaList.AddRange(Composer.OperaList);
            }
            return Task.CompletedTask;
        }
        private RelayCommand<Opera> _selectedOperaCmd;
        public RelayCommand<Opera> OperaSelectedCommand =>
            _selectedOperaCmd ??
            (_selectedOperaCmd = new RelayCommand<Opera>((opera) =>
            {
                var tuple = new Tuple<Composer, Opera>(Composer, opera);
                Navigation.NavigateTo(ViewModelLocator.COMPOSER_OPERA, tuple);
            }));
    }
}
