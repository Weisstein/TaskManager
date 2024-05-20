using TaskManager.Data;
namespace TaskManager.Views;

public partial class AddNotePage : ContentPage
{
    private TaskManagerContext _db;

	public AddNotePage()
	{
		InitializeComponent();
	}

    public AddNotePage(TaskManagerContext db)
    {
        _db = db;
    }


}