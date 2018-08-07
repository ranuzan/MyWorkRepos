using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GamesCOM.Models
{
    public static class Global
    {
        public static int sum { get; set; }

        public static List<Game> cart { get; set; }

        //recives a game name and find its index in the cart
        public static int findGameIndex(string name)
        {
            for (int i = 0; i < cart.Count(); i++)
            {
                if (name == cart[i].name)
                {
                    return i;
                }
            }
            return -1;
        }

        //encrypts a given a string
        public static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

    }

}