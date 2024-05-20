using TaskManager.Data;
using TaskManager.Models;
namespace TaskManager.Views;

public partial class AddNotePage : ContentPage
{
	public AddNotePage()
	{
		InitializeComponent();
	}

    async void RemoveButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    async void SaveButtonClicked(object sender, EventArgs e)
    {
        var note = new Notes
        {
            Title = title.Text,
            Text = text.Text,
            CreatedOn = DateTime.Now
        };
        using (var db = new TaskManagerContext())
        {
            db.Notes.Add(note);
            await db.SaveChangesAsync();
        }
        await Navigation.PopModalAsync();
    }
}