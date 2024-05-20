using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace TaskManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Preferences.Get("theme", "light") == "dark")
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
                if (Application.Current.UserAppTheme == AppTheme.Dark)
                handler.PlatformView.TextCursorDrawable.SetTint(Colors.White.ToAndroid());
                else
                handler.PlatformView.TextCursorDrawable.SetTint(Colors.Black.ToAndroid());
#endif
            });


            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());


#endif
            });


            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());


#endif
            });
 

             MainPage = new AppShell();
        }
    }
}
