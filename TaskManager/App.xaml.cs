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
            MainPage = new AppShell();
        }
    }
}
