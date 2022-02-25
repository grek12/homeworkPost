using homeworkPost.ViewsModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace homeworkPost
{
   
    public partial class MainPage : ContentPage

    {

        private readonly MPVM _vm = new MPVM();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm;        }
    }
}
