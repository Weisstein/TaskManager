using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class TaskPage : ContentPage
{
	Tasks task;

	public TaskPage(Tasks tasks)
	{
		InitializeComponent();
		BindingContext = tasks;
		this.task = tasks;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		using (var db = new TaskManagerContext())
		{
			subTaskList.BindingContext = db;
		}
    }
}