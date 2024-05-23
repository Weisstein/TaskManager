using Microsoft.Maui.Controls;
using TaskManager.Data;
using TaskManager.Models;
namespace TaskManager.Views;

public partial class AddNotePage : ContentPage
{

    static DateTime dateTime;

	public AddNotePage()
	{
		InitializeComponent();
        dateTime = DateTime.Now;
        date.Date = dateTime;
        time.Time = dateTime.TimeOfDay;
	}

    async void RemoveButtonClicked(object sender, EventArgs e)
    {
        if (text.IsSoftInputShowing())
            await text.HideSoftInputAsync(System.Threading.CancellationToken.None);
        await Navigation.PopModalAsync();

    }

    private void OnChange(object sender, TextChangedEventArgs e)
    {
        charCounter.Text = text.Text.Length.ToString();
    }

    async void SaveButtonClicked(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(title.Text) && !string.IsNullOrEmpty(text.Text))
        {
            var note = new Notes
            {
                Title = title.Text,
                Text = text.Text,
                CreatedOn = dateTime
            };
            using (var db = new TaskManagerContext())
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
            }
        }
        if (text.IsSoftInputShowing())
            await text.HideSoftInputAsync(System.Threading.CancellationToken.None);
        await Navigation.PopModalAsync();
    }
}