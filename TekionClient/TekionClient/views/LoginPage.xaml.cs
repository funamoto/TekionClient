using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TekionClient
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            loginButton.Clicked += LoginButton_Clicked;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            SetLoading(true);
            var connection = new Connection(usernameEntry.Text, tokenEntry.Text);
            var result = await connection.GetDisplay();
            if (result.IsSuccessStatusCode)
            {
                SetLoading(false);
                failedLabel.IsVisible = false;
                await Navigation.PushAsync(new VotePage(connection));
            }
            else
            {
                SetLoading(false);
                failedLabel.IsVisible = true;
            }
        }

        private void SetLoading(object p)
        {
            throw new NotImplementedException();
        }

        private void SetLoading(Boolean loading)
        {
            loginButton.IsVisible = !loading;
            statusLabel.IsVisible = loading;
        }
    }
}
