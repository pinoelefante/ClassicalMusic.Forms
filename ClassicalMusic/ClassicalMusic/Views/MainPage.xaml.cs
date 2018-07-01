using ClassicalMusic.ViewModels;
using pinoelefante.ViewModels;
using pinoelefante.Views;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassicalMusic.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MyTabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            (BindingContext as MyViewModel).Navigation.Initialize(navigationPage, ViewModelLocator.COMPOSER_LIST);
        }
	}
}