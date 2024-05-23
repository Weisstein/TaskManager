using TaskManager.Models;

namespace TaskManager.Views;

public partial class ProjectPage : TabbedPage
{
	public ProjectPage(Project project)
	{
		InitializeComponent();
		BindingContext = project;
	}
}