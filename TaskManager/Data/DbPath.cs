namespace TaskManager.Data
{
    public class DbPath
    {
        public static string GetPath(string dbName)
        {
            string dbPath = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                dbPath = Path.Combine(dbPath, dbName);
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                dbPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dbPath = Path.Combine(dbPath,"..","Library",dbName);
            }
        }
    }
}
