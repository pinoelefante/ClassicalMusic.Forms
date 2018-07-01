using ClassicalMusic.Models;
using ClassicalMusic.Services;
using GalaSoft.MvvmLight.Views;
using pinoelefante.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalMusic.ViewModels
{
    public class MainPageViewModel : MyViewModel
    {
        public MainPageViewModel(INavigationService n) : base(n)
        {
            Task.Factory.StartNew(() =>
            {
                ComposerList.AddRange(AssemblyFileReader.ReadLocalJson<List<Composer>>("music.json"));
            });
        }
    }
}
