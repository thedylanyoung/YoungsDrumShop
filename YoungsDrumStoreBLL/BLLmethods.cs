using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoungsDrumStoreBLL.Models;
using System.Security.Cryptography;

namespace YoungsDrumStoreBLL
{
    public class BLLmethods
    {
        public decimal CalculateTotalPrice(BusinessModel businessModel)
        {
            foreach (DrumBO drum in businessModel.drumList)
            {
                businessModel.CartTotal = businessModel.CartTotal + (drum.DrumPrice * drum.CheckoutQty);
            }

            foreach (CymbalBO cymbal in businessModel.cymbalList)
            {
                businessModel.CartTotal = businessModel.CartTotal + (cymbal.CymbalPrice * cymbal.CheckoutQty);
            }

            return businessModel.CartTotal;
        }

        public string PassWordHash(string passwordToHash)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(passwordToHash);
            byte[] hashedBytes = md5.ComputeHash(inputBytes);
            StringBuilder newPassword = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                newPassword.Append(hashedBytes[i].ToString("X2"));//X2 Turns it into hexa decimal
            }
            return newPassword.ToString();
        }
    }
}
