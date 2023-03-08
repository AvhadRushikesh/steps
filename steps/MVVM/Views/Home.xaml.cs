using System.Diagnostics;
using System.Threading.Tasks;
using System;
using CommunityToolkit.Maui.Alerts;
using steps.MVVM.Views;
using steps.MVVM.ViewModels;
using Microsoft.Maui.Graphics.Converters;

namespace steps.MVVM.Views;

public partial class Home : ContentPage
{
    bool isRandom;
    string hexValue;
    public Home()
	{
		InitializeComponent();

        BindingContext = new BGColorViewModel();
	}

    #region Comment


    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());
        btnRandom.BackgroundColor = color;
        Container.Background = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var random = new Random();
        var color = Color.FromRgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256));
        SetColor(color);

        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
        isRandom = false;
    }


    #endregion

    private void SaveBackGround(object sender, EventArgs e)
    {
        var testget = hexValue;

        // ColorTypeConverter converter = new ColorTypeConverter();
        // Color color = (Color)(converter.ConvertFromInvariantString(testget));


        // Container.BackgroundColor = color;



        //await Navigation.PushAsync(new Movies());
    }
}