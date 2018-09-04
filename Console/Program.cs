using System;
using Cripto;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            string senha = "123456";
            string salt = "asdfg";
            string hash = "efe8deeab66b584b31dcc081be17956f";

            System.Console.WriteLine(string.Format("Senha: {0}", senha));
            System.Console.WriteLine(string.Format("SALT: {0}", salt));
            System.Console.WriteLine(string.Format("HASH: {0}", hash));
            
            string md5Gerado = MD5Hash.GerarHashMD5(senha, salt);

            System.Console.WriteLine(string.Format("HASH Gerado: {0}", md5Gerado));
            System.Console.WriteLine(string.Format("HASH Gerado igual ao Informado: {0}", hash.Equals(md5Gerado, StringComparison.OrdinalIgnoreCase)));
            System.Console.ReadKey();
        }
    }
}
