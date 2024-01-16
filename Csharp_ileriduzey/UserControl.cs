using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_ileriduzey
{
    public static class UserControl
    {
        public static bool Control(User user)
        {
            var retval = true;
            var props = user.GetType().GetProperties();//degıskenın tıp ve ozellıklerını getırıyor
            foreach (var item in props)
            {
                //degısken uzerındekı tum attrıbuteları sorguluyor ve any ile varmı yokmu kontrolunu saglıyor
                if (item.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
                {
                    //attrıbutun uygulandıgı property
                    var val = item.GetValue(user) as string;
                    if (string.IsNullOrEmpty(val))
                    {
                        //deger bossa false donecek
                        retval = false;
                    }
                }
                
            }
            return retval;
        }
    }
}
