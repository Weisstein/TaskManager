using Microsoft.Extensions.Logging;
using TaskManager.Data;
using TaskManager.Views;

namespace TaskManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddDbContext<TaskManagerContext>();
            builder.Services.AddTransient<NotesPage>();
            builder.Services.AddTransient<AddNotePage>();

            var dbContext = new TaskManagerContext();
            if (dbContext.Database != null)
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
