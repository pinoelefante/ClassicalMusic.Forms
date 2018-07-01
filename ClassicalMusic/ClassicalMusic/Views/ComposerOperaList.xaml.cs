using pinoelefante.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassicalMusic.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ComposerOperaList : MyContentPage
	{
		public ComposerOperaList ()
		{
			InitializeComponent ();
		}
        public ComposerOperaList(object par) : base(par)
        {
            InitializeComponent();
        }
	}
}