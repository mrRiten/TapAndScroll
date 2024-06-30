namespace TapAndScroll.Web.WebHelpers
{
    public static class ImageWebHelper
    {

        public static void SaveImages(int productId, ICollection<IFormFile> files, IWebHostEnvironment webHost)
        {
            var uploadDirectory = Path.Combine(webHost.WebRootPath, $"upload/{productId}");

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var filePath = Path.Combine(uploadDirectory, Path.GetFileName(file.FileName));

                    using var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(stream);
                }
            }
        }

        public static void DeleteImages(int productId, IWebHostEnvironment webHost)
        {
            var uploadDirectory = Path.Combine(webHost.WebRootPath, $"upload/{productId}");

            if (Directory.Exists(uploadDirectory))
            {
                var files = Directory.GetFiles(uploadDirectory);
                foreach (var file in files)
                {
                    File.Delete(file);
                }

                Directory.Delete(uploadDirectory);
            }
        }
    }
}
