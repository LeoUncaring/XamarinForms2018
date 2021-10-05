using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPageXF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TipoPagina.Carousel.TipoPagina3();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
