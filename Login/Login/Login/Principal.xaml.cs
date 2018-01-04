using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Login.Model;

namespace Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Principal : ContentPage
	{
		public Principal ()
		{
			InitializeComponent ();
		}

        private async void BtnInsert_Clicked(object sender, EventArgs e)
        {
            lblStatusMensaje.Text = string.Empty;
            UserRepository.Instancia.AddNewUser(txtUsername.Text, txtEmail.Text, txtPassword.Text);
            lblStatusMensaje.Text = UserRepository.Instancia.EstadoMensaje;



        }

        private async void BtnAllUser_Clicked(object sender, EventArgs e)
        {
            var allUser = UserRepository.Instancia.GetAllUser();
            userList.ItemsSource = allUser;
            lblStatusMensaje.Text = UserRepository.Instancia.EstadoMensaje;
            //App.MasterD.IsPresented = false;
            //await App.MasterD.Detail.Navigation.PushAsync(new Primera());
            // await DisplayAlert("Alert", "You have been alerted", "OK");

        }
    }
}