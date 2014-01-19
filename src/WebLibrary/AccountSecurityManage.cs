using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Presentation.UIView;
using WebLibrary.Helper;

namespace WebLibrary
{
    public static class AccountSecurityManage
    {
        public static string MD5Password(string password)
        {
            var instance = MD5.Create();
            var bytePassword = Encoding.UTF8.GetBytes(password);
            var data = instance.ComputeHash(bytePassword);
            StringBuilder sb = new StringBuilder();
            for (var index = 0; index < data.Length; index++)
            {
                sb.Append(data[index].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string GenerateRadomPassword()
        {
            var random = new Random();
            var randomSequeue = new Random();
            StringBuilder sb = new StringBuilder();
            for (var index = 0; index < 10; index++)
            {
                var randomValue = random.Next(10);
                var sequeue = randomSequeue.Next(1, 4);
                switch (sequeue)
                {
                    case 1:
                        sb.Append(((char)((97) + randomValue)).ToString());
                        break;
                    case 2:
                        sb.Append(((char)((65) + randomValue)).ToString());
                        break;
                    default:
                        sb.Append(randomValue.ToString());
                        break;
                }
            }
            return sb.ToString();
        }

        public static string SerializeAccountInfo(LoginUserPresentation user)
        {
            var accountJson = SerializerHelper.Serialize<LoginUserPresentation>(user);
            return accountJson;
        }

        public static LoginUserPresentation DeserializeAccountInfo(string json)
        {
            return SerializerHelper.Deserialize<LoginUserPresentation>(json);
        }

        public static string GetDefaultPassword()
        {
            return MD5Password("1234");
        }
    }
}
