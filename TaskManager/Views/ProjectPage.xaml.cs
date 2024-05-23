using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class ProjectPage : ContentPage
{
	public ProjectPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		using (var db = new TaskManagerContext())
		{
			projects.BindingContext = db.Projects.ToList();
		}
    }

    private async void OnAddButton_Clicked(object sender, EventArgs e)
    {
		string title = await DisplayPromptAsync("Создание проекта","Название проекта","Добавить","Отмена");
		Project project = new Project()
		{
			Title = title
		};

		using (var db = new TaskManagerContext())
		{
			db.Projects.Add(project);
			await db.SaveChangesAsync();
		}
		base.OnAppearing();
    }
}