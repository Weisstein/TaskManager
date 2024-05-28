using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class ProjectPage : ContentPage
{
    Project project;
    int position; 
	public ProjectPage(Project project)
	{
		InitializeComponent();
		BindingContext = project;
        this.project = project;
        RefreshData();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshData();
    }

    private void RefreshData()
    {
        using (var db = new TaskManagerContext())
        {
            activityList.ItemsSource = db.Activitys.Include(a=>a.Tasks).Where(a => a.ProjectId == project.Id).ToList();
        }
        activityList.Position = position;
    }

    private void OnPositionChanget(object sender, PositionChangedEventArgs e)
    {
        position = e.PreviousPosition;
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

    private async void ToolbarItemEdit_Clicked(object sender, EventArgs e)
    {
        string title = await DisplayPromptAsync("Изменение имени прооекта", "Название проекта", "Сохранить", "Отмена", initialValue: Title);

        if (!string.IsNullOrEmpty(title))
        {
            using (var db = new TaskManagerContext())
            {
                db.Projects.Where(p => p.Id == project.Id).ExecuteUpdate(p=>p.SetProperty(p=>p.Title,title));
                await db.SaveChangesAsync();
            } 
            Title = title;
            activityList.Position = position;
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
            RefreshData();
        }
    }

    private async void OnTaskAddClick(object sender, EventArgs e)
    {
        string title = await DisplayPromptAsync("Создание задачи", "Название задачи", "Добавить", "Отмена");
        var activity = activityList.CurrentItem as Activity;

        if (!string.IsNullOrEmpty(title))
        {
            Tasks task = new Tasks()
            {
                Created = DateTime.Now,
                ActivityId = activity.Id,
                Title = title
            };
            using (var db = new TaskManagerContext())
            {
                db.Tasks.Add(task);
                await db.SaveChangesAsync();
            }
            RefreshData();
        }
    }

    private async void OnEditClick(object sender, EventArgs e)
    {
        var activity = activityList.CurrentItem as Activity;
        string title = await DisplayPromptAsync("Изменение имени прооекта", "Название проекта", "Сохранить", "Отмена", initialValue: activity.Title);
        if (!string.IsNullOrEmpty(title))
        {
            using (var db = new TaskManagerContext())
            {
                db.Activitys.Where(a => a.Id == activity.Id).ExecuteUpdate(a => a
                .SetProperty(a=>a.Title,title));
                await db.SaveChangesAsync();
            }
            RefreshData();
        }

    }

    private async void taskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        await Navigation.PushAsync(new TaskPage(e.CurrentSelection.FirstOrDefault() as Tasks));
    }
}