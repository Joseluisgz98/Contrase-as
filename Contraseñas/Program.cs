using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


class Program
{
    public static void buscar()
    {
        //poner la ruta del archivo 
        string ruta = "C:\\Users\\usuariot\\source\\repos\\Contraseñas\\Contraseñas\\2151220-passwords.txt";
        List<string> lineas = File.ReadAllLines(ruta).ToList();
        Random r = new Random();
        int numero = r.Next(lineas.Count);
        String contraElegida = lineas[numero];
        String encriptado = GetSHA256(contraElegida);

        System.Console.WriteLine("la contraseña elegida es " + contraElegida);
        System.Console.WriteLine("Y encriptada es " + encriptado);
        for (int i = 0; i < lineas.Count; i++)
        {
            string line = GetSHA256(lineas[i]);

            if (encriptado == line)
            {
                System.Console.WriteLine("encontraodo " + encriptado);
                break;
            }

        }
    }
    private static void Main(string[] args)
    {
        buscar();
      

        
    
    }
    public static string GetSHA256(string str)
    {
        SHA256 sha256 = SHA256Managed.Create();
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] stream = null;
        StringBuilder sb = new StringBuilder();
        stream = sha256.ComputeHash(encoding.GetBytes(str));
        for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
        return sb.ToString();
    }
}