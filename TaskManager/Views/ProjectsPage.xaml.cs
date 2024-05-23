using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManager.Data;
using TaskManager.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.Views;

public partial class ProjectsPage : ContentPage
{
	public ProjectsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		using (var db = new TaskManagerContext())
		{
			projects.ItemsSource = db.Projects.ToList();
		}
    }

    private async void OnAddButton_Clicked(object sender, EventArgs e)
    {
		string title = await DisplayPromptAsync("Создание проекта","Название проекта","Добавить","Отмена");
		
		if(!string.IsNullOrEmpty(title))
		{
			Project project = new Project()
			{
				Title = title
			};
			using (var db = new TaskManagerContext())
			{
				db.Projects.Add(project);
				await db.SaveChangesAsync();
			
			}
			OnAppearing();
		}
		
    }

	private async void OnItemClick(object sender, SelectionChangedEventArgs e)
	{
		await Navigation.PushAsync(new ProjectPage(e.CurrentSelection.FirstOrDefault() as Project));
	}

}