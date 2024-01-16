using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_ileriduzey
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw = null; 
            try
            {
                //belirtilen dosya yolundakı data klasorunu acıyor
                //Filemode.append denırse varolanın uzerine yenısını ekler
                bw = new BinaryWriter(new FileStream("C:\\vidobu\\data",FileMode.OpenOrCreate));
                bw.Write("Binary writer ile yazılan data\n");
                bw.Write(DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                bw.Close();
                bw.Dispose();
            }

            //------------------------------------------------------------------------------------------------ file

            var filepath = @"c:\vidobu\cs_file.txt";
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();//eger dosya ilgili dızınde yoksa dosyayı olustur ve kapatt..
            }
            var text = "ewonewbfbewobfouwebfbwebf";
            File.WriteAllText(filepath,text + Environment.NewLine); // environment 1 alt satıra iner
            var array = new[] { "Ocak", "Subat" };
            File.AppendAllLines(filepath, array); //dizi elemanlarını dosyaya yazar

            //------------------------------------------------------------------------------------------------  path
            var filepath2 = @"c:\vidobu\cs_file.txt";
            Console.WriteLine(Path.GetDirectoryName(filepath2));
            Console.WriteLine(Path.GetFileNameWithoutExtension(filepath2));

            //------------------------------------------------------------------------------------------------  filestream
            var filepath3 = @"c:\vidobu\cs_file.txt";
            var fs = new FileStream(filepath3, FileMode.Open, FileAccess.ReadWrite); //dosyaya erişip okuma işlemi yapılacagını bıldırıyor
            var fi = new FileInfo(filepath3);//dosyadakı verının kac byte oldugu bılgısıne ulasılıyor
            var byteArr = new byte[fi.Length];//dosya okuma ıcın byte turunden bır array gerekıyor
            fs.Read(byteArr,0,byteArr.Length);//ıcerıgı arrayın uzunlugu kadar blok blok okuyor
            Console.WriteLine(Encoding.UTF8.GetString(byteArr));
            Console.WriteLine(new string('-',50));//50 tane tire
            var str = "Filestream ile yazıldı";
            var strArr = Encoding.UTF8.GetBytes(str);
            fs.Write(strArr,0,strArr.Length);//dosyaya ıcerık yazıyor
            fs.Close(); 
            fs.Dispose();

            //------------------------------------------------------------------------------------------------  streamreader
            var filepath4 = @"c:\vidobu\cs_file.txt";
            var sr = new StreamReader(filepath4);
            Console.WriteLine((char)sr.Read()); //sadece 1 karakter okur
            var ch = new char[1000];
            Console.WriteLine(sr.Read(ch, 0, 20));//ilk 20 karakteri okur
            Console.WriteLine(sr.ReadToEnd());//tumunu okur
            while (!sr.EndOfStream) //satır satır okuma
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();

            //------------------------------------------------------------------------------------------------  custom attribute
            Console.WriteLine(new string('-', 50));
            var user = new User { Name = "mert" };
            if (UserControl.Control(user))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            Console.ReadKey();
        }
    }
}
