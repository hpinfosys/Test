﻿namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
//		await Navigation.PushAsync(new TabPage());
		await DisplayAlert("Alert", "You have been clicked", "OK");
	}
}
