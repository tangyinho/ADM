using System.Text;

namespace ADM.Server.Helpers
{
    public static class Md5Helper
    {
        public static string ToMD5(this string str)
        {
            using (var cryptoMD5 = System.Security.Cryptography.MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(str);
                 
                var hash = cryptoMD5.ComputeHash(bytes);
                 
                var md5 = BitConverter.ToString(hash)
                  .Replace("-", String.Empty)
                  .ToUpper();

                return md5;
            }
        }
    }
}
