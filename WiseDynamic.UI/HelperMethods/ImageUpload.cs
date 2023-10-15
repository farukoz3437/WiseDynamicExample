using DtoLayer.Dtos.UserDtos;

namespace WiseDynamic.UI.HelperMethods
{
    public static class ImageUpload
    {
        public static string Upload(string url,string imgData)
        {
            var fileName = "";
            if(imgData.Contains("image/jpg"))
            {
                fileName= $"image_{DateTime.Now.Ticks}.jpg";
            }
            if (imgData.Contains("image/jpeg"))
            {
                fileName = $"image_{DateTime.Now.Ticks}.jpeg";
            }
            if (imgData.Contains("image/png"))
            {
                fileName = $"image_{DateTime.Now.Ticks}.png";
            }
            var filePath = Path.Combine(url, fileName);
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    var data = Convert.FromBase64String(imgData.Split(',')[1]);
                    bw.Write(data);
                    bw.Close();
                }
                fs.Close();
            }
            return fileName;
        }
    }
}
