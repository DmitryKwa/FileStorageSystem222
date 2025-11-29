namespace FileStorageSystem.Services
{
    public class FileService
    {
        public string root { get { return $"{Directory.GetCurrentDirectory()}\\Uploads"; } }

        //public async void Create()
        //{
        //    string dir = Path.Combine(root, path);
        //}

        //public async void Update()
        //{
        //    string dir = Path.Combine(root, path);
        //}

        //public async void Delete()
        //{
        //    string dir = Path.Combine(root, path);
        //}

        //public async void Create()
        //{

        //}
    }
}
