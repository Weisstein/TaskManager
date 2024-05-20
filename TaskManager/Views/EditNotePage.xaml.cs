using TaskManager.Models;

namespace TaskManager.Views;

public partial class EditNotePage : ContentPage
{
	private Notes note;

	public EditNotePage(Notes note)
	{
        InitializeComponent();
		this.note = note;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = note;
    }


}