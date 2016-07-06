using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TekionClient
{
    public partial class VotePage : ContentPage
    {

        private Connection connection;

        public VotePage(Connection connection)
        {
            InitializeComponent();

            this.connection = connection;

            coldButton.Clicked += ColdButton_Clicked;
            goodButton.Clicked += GoodButton_Clicked;
            hotButton.Clicked += HotButton_Clicked;
        }

        private async void GoodButton_Clicked(object sender, EventArgs e)
        {
            statusLabel.Text = await connection.Vote(0);
        }

        private async void ColdButton_Clicked(object sender, EventArgs e)
        {
            statusLabel.Text = await connection.Vote(1);
        }

        private async void HotButton_Clicked(object sender, EventArgs e)
        {
            statusLabel.Text =  await connection.Vote(2);
        }
    }
}
