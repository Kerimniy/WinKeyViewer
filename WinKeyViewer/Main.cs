using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Timers;

namespace WinS
{
    public static class StringExtensions
    {

        public static string PadCenter(this string input, int length, char _char)
        {
            string baseInput = input;
            input = input.PadLeft(length / 2+baseInput.Length/2, _char);
            input = input.PadRight(length, _char);
            return input;
        }
    }

    class MainClass()
    {
        static void Main(string[] args)
        {
            string key = GetActivationKey();
            string id = GetWinProductId();
            string name = GetWinName();
            string version = GetWinVersion();

            int _length = key.Length + id.Length + name.Length + version.Length + 8;

            int[] arr = {key.Length, id.Length, name.Length, version.Length};
            int mLength = arr.Max()+2;
            
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Console.WriteLine("\n");
            Console.WriteLine("+" + "".PadCenter(mLength * 2 + 5, '-') + "+");
            Console.WriteLine("|"+"| WinKeyViewer v.0.1 |".PadCenter(mLength*2+5, '=')+"|");

            Console.WriteLine("+-"+"".PadLeft(mLength,'-')+"-+-"+ "".PadLeft(mLength, '-')+"-+");

            Console.WriteLine("| "+"OS".PadCenter(mLength,' ')+" | "+ "Version".PadCenter(mLength, ' ')+" |");
            Console.WriteLine("+-" + "".PadLeft(mLength, '-') + "-+-" + "".PadLeft(mLength, '-') + "-+");
            Console.WriteLine("| "+name.PadCenter(mLength,' ')+" | "+ version.PadCenter(mLength, ' ')+" |");

            Console.WriteLine("+-" + "".PadLeft(mLength, '-') + "-+-" + "".PadLeft(mLength, '-') + "-+");
            Console.WriteLine("| " + "Id".PadCenter(mLength, ' ') + " | " + "Key".PadCenter(mLength, ' ') + " |");
            Console.WriteLine("+-" + "".PadLeft(mLength, '-') + "-+-" + "".PadLeft(mLength, '-') + "-+");
            Console.WriteLine("| " + id.PadCenter(mLength, ' ') + " | " + key.PadCenter(mLength, ' ') + " |");
            Console.WriteLine("+-" + "".PadLeft(mLength, '-') + "-+-" + "".PadLeft(mLength, '-') + "-+");

           
            while (true)
            {
                Console.ReadKey();
                Task.Delay(9000000);
            }

        }


        static string GetActivationKey()
        {
            var sth = "";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\SoftwareProtectionPlatform"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("BackupProductKeyDefault");
                        if (o != null)
                        {
                            sth = o as String;  
                        }
                        return sth;
                    }
                    else
                    {
                        return "Couldn't find";
                    }
                }
            }
            catch (Exception ex)  
            {
                return ("Error: " + ex.ToString());
            }
            
        }


        static string GetWinProductId()
        {
            var sth = "";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\DefaultProductKey2"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("ProductId");
                        if (o != null)
                        {
                            sth = o as String;
                        }
                        return sth;
                    }
                    else
                    {
                        return "Couldn't find";
                    }
                }
            }
            catch (Exception ex)
            {
                return ("Error: " + ex.ToString());
            }

        }


        static string GetWinVersion()
        {
            var sth = "";
            try
            {
                
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("DisplayVersion");
                        Object o1 = key.GetValue("WinREVersion");


                        if (o != null)
                        {
                           
                            sth = (o as string).ToString() + " "+ (o1 as string).ToString();
                           
     
                        }
                        else
                        {
                            return "Couldn't find";
                        }
                        return sth;
                    }
                    else
                    {
                        return "Couldn't find";
                    }
                }
            }
            catch (Exception ex)
            {
                return ("Error: " + ex.ToString());
            }

        }


        static string GetWinName()
        {
            var sth = "";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("ProductName");
                        if (o != null)
                        {
                            sth = o as string;

                        }
                        return sth;
                    }
                    else
                    {
                        return "Couldn't find";
                    }
                }
            }
            catch (Exception ex)
            {
                return ("Error: " + ex.ToString());
            }

        }
        
        
        //--NO-IN-USE--

        /*
        static void NasratVReestr()
        {
            var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Kerimniy");
            key.SetValue("Param1", "NET");
            key.SetValue("Tipo Vazhniu", "Da");
            key.SetValue("Tipo Nevazhniu", "Net");
            key.SetValue("Popalsya", "Da");
            key.SetValue("Ya Nasral V Reestr", "Da");
            key.Close();
        }
        */
    }
}