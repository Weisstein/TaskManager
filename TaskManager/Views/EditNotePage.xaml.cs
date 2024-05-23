using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Views;

public partial class EditNotePage : ContentPage
{

	public EditNotePage(Notes note)
	{
        InitializeComponent();
		BindingContext = note;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (text.Text.Length != 0)
            charCounter.Text = text.Text.Length.ToString();

    }

    private void onChange(object sender, TextChangedEventArgs e)
    {
        charCounter.Text = text.Text.Length.ToString();
    }

    private async void ToolbarItemDelete_Clicked(object sender, EventArgs e)
    {
        Notes note = (Notes)BindingContext;
        
        if(await DisplayAlert("Удаление","Вы действительно хотите удалить заметку?", "Да", "Нет"))
        {
            using (var db = new TaskManagerContext())
            {
                db.Notes.Where(n => n.Id == note.Id).ExecuteDelete();
                await db.SaveChangesAsync();
            }
            await Navigation.PopAsync();
        }
    }

    private async void ToolbarItemSave_Clicked(object sender, EventArgs e)
    {
        Notes note = (Notes)BindingContext;
        using (var db = new TaskManagerContext())
        {
            db.Notes.Where(n => n.Id == note.Id).ExecuteUpdate(n =>
                n.SetProperty(n => n.Title, title.Text)
                 .SetProperty(n => n.Text, text.Text)
                );
            await db.SaveChangesAsync();
        }
        await Navigation.PopAsync();
    }
}