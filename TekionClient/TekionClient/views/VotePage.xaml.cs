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
        private DisplayModel result;

        public VotePage(Connection connection, DisplayModel result)
        {
            InitializeComponent();

            this.connection = connection;

            coldButton.Clicked += ColdButton_Clicked;
            goodButton.Clicked += GoodButton_Clicked;
            hotButton.Clicked += HotButton_Clicked;

            UpdateResult(result);
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
            statusLabel.Text = await connection.Vote(2);
        }

        private async void OnUpdateLabelClicked(object sender, EventArgs e)
        {
            var response = await connection.GetDisplay();
            if (response == null)
            {
                statusLabel.Text = "update failed";
                return;
            }
            else
            {
                UpdateResult(response);
                statusLabel.Text = "update success";
            }
        }

        private void UpdateResult(DisplayModel result)
        {
            if (result == null)
            {
                return;
            }

            switch (result.ResultCode)
            {
                case 1:
                    resultImage.Source = "result_cold.png";
                    resultLabel.Text = "cold";
                    break;
                case 2:
                    resultImage.Source = "result_hot.png";
                    resultLabel.Text = "hot";
                    break;
                default:
                    resultImage.Source = "result_good.png";
                    resultLabel.Text = "good";
                    break;
            }

            switch (result.WeatherCode)
            {
                case 1:
                    weatherImage.Source = "weather_sunny.png";
                    weatherLabel.Text = "snnny";
                    break;
                case 2:
                    weatherImage.Source = "weather_cloud.png";
                    weatherLabel.Text = "cloudy";
                    break;
                case 3:
                    weatherImage.Source = "weather_rain.png";
                    weatherLabel.Text = "rainy";
                    break;
                case 4:
                    weatherImage.Source = "weather_snow.png";
                    weatherLabel.Text = "snowy";
                    break;
                default:
                    weatherImage.Source = "weather_none.png";
                    weatherLabel.Text = "none";
                    break;
            }

            if (result.Temperature == null)
            {
                temparatureLabel.Text = "--°";
            }
            else
            {
                temparatureLabel.Text = result.Temperature.Value.ToString("#.0") + "°";
            }
        }
    }
}
