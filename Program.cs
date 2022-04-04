using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StreamReader f = new StreamReader("C:\\source.txt");
            string a = "";
            while (!f.EndOfStream)
            {
                a+= f.ReadLine();
            }
            f.Close();
            Regex regex = new Regex(@"\w*");
            MatchCollection matches = regex.Matches(a);
            if (matches.Count > 0)
            {
                a = "";
                foreach (Match match in matches)
                    a+=match.Value+" ";
            }
            string z = "";
            a = a.Trim();
            for (int i = 0; i < a.Length; i++)

                if (a[i] == ' ')
                {
                    if (z[z.Length - 1] != ' ')
                        z += ' ';
                }
                else
                    z += a[i];
            a = z;
            using (StreamWriter writer = new StreamWriter("C:\\result.txt", false))
            {
                await writer.WriteLineAsync(a);
            }
            Console.WriteLine("Данные записаны в файл 'result' расположенному по пути C:\\result.txt");
        }

    }
}
