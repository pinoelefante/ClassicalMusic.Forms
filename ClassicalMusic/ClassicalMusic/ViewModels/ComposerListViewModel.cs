using ClassicalMusic.Models;
using GalaSoft.MvvmLight.Views;
using pinoelefante.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;

namespace ClassicalMusic.ViewModels
{
    public class ComposerListViewModel : MyViewModel
    {
        public ComposerListViewModel(INavigationService n) : base(n) { }
        public MyObservableCollection<ComposerGroup> Composers { get; } = new MyObservableCollection<ComposerGroup>();
        public MyObservableCollection<Composer> ComposerSimpleList { get; } = new MyObservableCollection<Composer>();
        public override Task NavigatedToAsync(object parameter = null)
        {
            return Task.Factory.StartNew(async () =>
            {
                do
                {
                    await Task.Delay(100);
                } while (ComposerList.Count == 0);
                Device.BeginInvokeOnMainThread(() =>
                {
                    if(Device.RuntimePlatform.Equals(Device.iOS)) //iOS 
                    {
                        if (ComposerSimpleList.Any())
                            return;
                        ComposerSimpleList.AddRange(ComposerList);
                        
                    }
                    else 
                    {
                        if (Composers.Any())
                            return;
                        var groups = ComposerList.GroupBy(x => x.Name.First().ToString());
                        foreach (var group in groups)
                        {
                            var coll = new ComposerGroup();
                            coll.AddRange(group);
                            coll.ShortName = group.Key;
                            Composers.Add(coll);
                        }
                    }
                });
            });
        }
        private RelayCommand<Composer> _itemTapped;
        public RelayCommand<Composer> ItemTappedCommand =>
            _itemTapped ??
            (_itemTapped = new RelayCommand<Composer>((composer) =>
            {
                Debug.WriteLine(composer.Name);
                if (composer.Categories != null && composer.Categories.Any())
                {
                    Debug.WriteLine("Apri categorie");
                    Navigation.NavigateTo(ViewModelLocator.COMPOSER_CATEGORIES, composer);
                }
                else
                {
                    Debug.WriteLine("Apri opere");
                    Navigation.NavigateTo(ViewModelLocator.COMPOSER_OPERA_LIST, composer);
                }
            }));

        public class ComposerGroup : MyObservableCollection<Composer>
        {
            public string ShortName { get; set; }
        }
    }
}
