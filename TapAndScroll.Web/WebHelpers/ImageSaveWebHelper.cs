namespace TapAndScroll.Web.WebHelpers
{
    public static class ImageSaveWebHelper
    {

        public static void SaveImages(int productId, ICollection<FormFile> files, IWebHostEnvironment webHost)
        {

            foreach (var file in files)
            {

                if (file == null && file.FileName.Length > 0)
                {
                    var uploadDirectory = Path.Combine(webHost.WebRootPath, $"upload/{productId}");

                    var filePath = Path.GetFileName(file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    };

                }
            }
        }
    }
}
