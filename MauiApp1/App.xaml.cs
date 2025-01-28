using System.Diagnostics;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
Debug.WriteLine("Start App()");
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
Debug.WriteLine("CreateWindow");
		return new Window(new MainPage());
	}

	protected override void OnStart()
	{
//		await Navigation.PushAsync(new TabPage());

Debug.WriteLine("OnStart");
	Windows[0].Page = new Flyout();

	}
}