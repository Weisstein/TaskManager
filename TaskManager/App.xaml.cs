namespace TaskManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Preferences.Get("theme", "light") == "dark")
            {
                Application.Current.UserAppTheme = AppTheme.Dark; set1.Text = "Светлая тема";
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light; set1.Text = "Темная тема";
            }
            MainPage = new AppShell();
        }
    }
}
