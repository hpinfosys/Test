using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using AndroidX.Activity;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        OnBackPressedDispatcher.AddCallback(this, new BackPress(this));
    }
}

class BackPress : OnBackPressedCallback
{
    private readonly Activity activity;
    private long backPressed;

    public BackPress(Activity activity) : base(true)
    {
        this.activity = activity;
    }

    public override void HandleOnBackPressed()
    {
        var navigation = Microsoft.Maui.Controls.Application.Current?.MainPage?.Navigation;
        if (navigation is not null && navigation.NavigationStack.Count <= 1 && navigation.ModalStack.Count <= 0)
        {
            const int delay = 2000;
            if (backPressed + delay > DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            {
                activity.FinishAndRemoveTask();
                Process.KillProcess(Process.MyPid());
            }
            else
            {
                Toast.MakeText(activity, "Close", ToastLength.Long)?.Show();
                backPressed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
        }
    }
}