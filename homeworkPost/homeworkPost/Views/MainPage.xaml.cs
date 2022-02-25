using homeworkPost.ViewsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace homeworkPost
{
    public partial class MainPage : ContentPage

    {

        private readonly MPVM _vm = new MPVM();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }
    }
}
