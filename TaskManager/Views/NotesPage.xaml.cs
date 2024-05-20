using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class NotesPage : ContentPage
{
	private TaskManagerContext _db;

    public NotesPage(TaskManagerContext db)
	{
		InitializeComponent();
		_db = db;
	}

    private async void onAddButtonClick(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new AddNotePage());
	}
}