using System.Collections.ObjectModel;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class NotesPage : ContentPage
{
    public NotesPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		using (var db = new TaskManagerContext())
		{
			var notes = db.Notes.OrderByDescending(n=>n.CreatedOn).ToList();
			noteList.ItemsSource = notes;
			
		}
	}

    private async void onAddButtonClick(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new AddNotePage());
	}

	private async void onItemClick(object sender, SelectionChangedEventArgs e)
	{
		await Navigation.PushAsync(new EditNotePage(e.CurrentSelection.FirstOrDefault() as Notes));
		
	}
}