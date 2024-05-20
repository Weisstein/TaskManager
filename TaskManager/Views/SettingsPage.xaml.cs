namespace TaskManager.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		if (Application.Current.UserAppTheme == AppTheme.Dark)
		{
            set1.Text = "Светлая тема";
			switch1.IsToggled = true;
        }
	}

    void theme_Swich_Toggled(object sender, ToggledEventArgs e)
	{
		switch (e.Value)
		{
			case true: Preferences.Set("theme", "dark"); Application.Current.UserAppTheme = AppTheme.Dark; set1.Text = "Светлая тема";  break;
			case false: Preferences.Set("theme", "light"); Application.Current.UserAppTheme = AppTheme.Light; set1.Text = "Темная тема"; break;
		}
			
	}
}