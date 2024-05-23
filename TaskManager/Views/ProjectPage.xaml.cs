using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class ProjectPage : ContentPage
{
    Project project;

	public ProjectPage(Project project)
	{
		InitializeComponent();
		BindingContext = project;
        this.project = project;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        using (var db = new TaskManagerContext())
        {
            activityList.ItemsSource = db.Activitys.Where(a=>a.ProjectId == project.Id).ToList();
        }
    }

    private async void ToolbarItemDelete_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Удаление", "Вы действительно хотите удалить проект?", "Да", "Нет"))
        {
            using (var db = new TaskManagerContext())
            {
                db.Projects.Where(p => p.Id == project.Id).ExecuteDelete();
                await db.SaveChangesAsync();
            }
            await Navigation.PopAsync();
        }
    }

    private async void OnAddButtonClick(object sender, EventArgs e)
    {
        string title = await DisplayPromptAsync("Создание активности", "Название активности", "Добавить", "Отмена");

        if (!string.IsNullOrEmpty(title))
        {
            Activity activity = new Activity()
            {
                ProjectId = project.Id,
                Title = title
            };
            using (var db = new TaskManagerContext())
            {
                db.Activitys.Add(activity);
                await db.SaveChangesAsync();

            }
            OnAppearing();
        }
    }
}