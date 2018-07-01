using ClassicalMusic.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using pinoelefante.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClassicalMusic.ViewModels
{
    public class ViewModelLocator
    {
        public const string COMPOSER_LIST = "ComposerList",
            COMPOSER_CATEGORIES = "ComposerCategories",
            COMPOSER_OPERA_LIST = "ComposerOperaList",
            COMPOSER_OPERA = "ComposerOpera";

        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<ComposerListViewModel>();
            SimpleIoc.Default.Register<ComposerCategoriesViewModel>();
            SimpleIoc.Default.Register<ComposerOperaListViewModel>();
            SimpleIoc.Default.Register<ComposerOperaViewModel>();
            
            RegisterPages();
        }
        public static void RegisterPages()
        {
            NavigationService.Configure(COMPOSER_LIST, typeof(ComposerList));
            NavigationService.Configure(COMPOSER_CATEGORIES, typeof(ComposerCategories));
            NavigationService.Configure(COMPOSER_OPERA_LIST, typeof(ComposerOperaList));
            NavigationService.Configure(COMPOSER_OPERA, typeof(ComposerOpera));
        }
        public static NavigationService NavigationService => (NavigationService)GetService<INavigationService>();
        public static T GetService<T>() => SimpleIoc.Default.GetInstance<T>();

        public MainPageViewModel MainPageVM => GetService<MainPageViewModel>();

        public ComposerListViewModel ComposerListVM => GetService<ComposerListViewModel>();
        public ComposerCategoriesViewModel ComposerCategoriesVM => GetService<ComposerCategoriesViewModel>();
        public ComposerOperaListViewModel ComposerOperaListVM => GetService<ComposerOperaListViewModel>();
        public ComposerOperaViewModel ComposerOperaVM => GetService<ComposerOperaViewModel>();
    }
}
