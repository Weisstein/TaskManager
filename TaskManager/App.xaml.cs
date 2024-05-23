using Microsoft.Maui.Platform;
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
                            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                            if (Application.Current.UserAppTheme == AppTheme.Dark)
                            handler.PlatformView.TextCursorDrawable.SetTint(Android.Graphics.Color.White);
                            else
                            handler.PlatformView.TextCursorDrawable.SetTint(Android.Graphics.Color.Black);
                            handler.PlatformView.SetPadding(0, 0, 0, 0);
#endif
            });

            Microsoft.Maui.Handlers.LabelHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID

                            handler.PlatformView.SetPadding(0, 0, 0, 0);
#endif  
            });

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                            handler.PlatformView.SetPadding(0,0,0,0);


#endif
            });


            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                            handler.PlatformView.SetPadding(0, 0, 0, 0);

#endif
            });

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                            if (!handler.PlatformView.IsInEditMode)
                                handler.PlatformView.SetTextColor(Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#919191")));
                            handler.PlatformView.SetPadding(0, 0, 0, 0);

#endif
            });

            Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                            if(!handler.PlatformView.IsInEditMode)
                                handler.PlatformView.SetTextColor(Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#919191")));
                            handler.PlatformView.SetPadding(0, 0, 0, 0);

#endif
            });

            MainPage = new AppShell();
        }
    }
}
