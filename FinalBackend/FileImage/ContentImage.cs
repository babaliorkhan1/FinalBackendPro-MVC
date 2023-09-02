namespace FinalBackend.FileImage
{
    public static class ContentImage
    {
        public static bool isImage(IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
    }
}
