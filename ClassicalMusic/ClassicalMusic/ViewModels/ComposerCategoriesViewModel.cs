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
    public class ComposerCategoriesViewModel : MyViewModel
    {
        public ComposerCategoriesViewModel(INavigationService n) : base(n)
        {
        }
        public override async Task NavigatedToAsync(object parameter = null)
        {
            await base.NavigatedToAsync(parameter);
            if (!(parameter is Composer))
                Navigation.GoBack();
            else
            {
                Composer = parameter as Composer;
            }
        }
        private Composer composer;
        public Composer Composer { get => composer; set => SetMT(ref composer, value); }
        private RelayCommand<Category> _catSelectedCmd;
        public RelayCommand<Category> CategorySelectedCommand =>
            _catSelectedCmd ??
            (_catSelectedCmd = new RelayCommand<Category>((category) =>
            {
                var tuple = new Tuple<Composer,Category>(Composer, category);
                Navigation.NavigateTo(ViewModelLocator.COMPOSER_OPERA_LIST, tuple);
            }));

    }
}
