using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Sys.Security
{
  using System.Security.Cryptography;

  public static  class SecurityExtensions
  {
  public static string ToMD5String(this string input)
  {
    // step 1, calculate MD5 hash from input
    MD5 md5 = MD5.Create();
    byte[] inputBytes = Encoding.ASCII.GetBytes(input);
    byte[] hash = md5.ComputeHash(inputBytes);

    // step 2, convert byte array to hex string
    var sb = new StringBuilder();
    foreach (byte t in hash)
    {
      sb.Append(t.ToString("X2"));
    }
    return sb.ToString();
  }
  }
}
