using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Classe criada para manuseio da criptografia
/// </summary>
namespace Cripto
{
    public static class MD5Hash
    {
        /// <summary>
        /// Classe responsável por gerar a chave MD5
        /// </summary>
        /// <param name="key">String que será transformada em MD5</param>
        /// <param name="salt">String Salt que foi usada para gerar o HASH</param>
        /// <returns></returns>
        public static string GerarHashMD5(string key, string salt)
        {
            //Objeto responsável por montar o hash MD5 e retornar
            StringBuilder sb = new StringBuilder();
                       
            //Objeto MD5 utilizado para gerar o Hash
            using (MD5 md5Hash = MD5.Create())
            {
                //Carrega em um array de bytes a combinação key + salt
                byte[] gerarHash = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(string.Format("{0}{1}", key, salt)));

                //Percorre o array de bytes para transforma-lo em uma string
                for (int i = 0; i < gerarHash.Length; i++)
                    sb.Append(gerarHash[i].ToString("X2"));
            }
            
            //Retorna o Hash para a combinação key + salt
            return sb.ToString();
        }
    }
}
