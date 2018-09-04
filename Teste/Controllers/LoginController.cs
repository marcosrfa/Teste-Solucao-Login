using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Teste.Models;

namespace Teste.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// POST api/Login
        /// </summary>
        /// <param name="login">Objeto Json Esperado
        /// Exemplo:
        /// { Login": "marcos","Senha": "123456"}</param>
        /// <returns>Http response</returns>
        public HttpResponseMessage Post([FromBody] Models.LoginVO login)
        {
            try
            {
                //Carrega dados do usuário para fazer o Login
                Usuario usuario = Usuario.BuscarUsuario(login.Login);

                //Verifica se o usuário passado como parâmetro existe na base
                if (usuario != null)
                {
                    //Transforma a Senha digitada + o SALT do usuário encontrado em Hash de MD5
                    string hashUsuario = Cripto.MD5Hash.GerarHashMD5(login.Senha, usuario.Salt);

                    //Compara o hash da base com o hash da senha informada + SALT do usuário
                    if(!hashUsuario.Equals(usuario.Hash, StringComparison.OrdinalIgnoreCase))
                        throw new Exception($"Senha inválida para o login '{login.Login}'");
                }
                else
                    //Se não achar o usuário, retorna este trecho de código.
                    throw new Exception($"Usuário '{login.Login}' não encontrado!");

                //Retorna a mensagem de OK mais o nome do usuário que foi Logado
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, usuario.NomeUsuario);
            }
            catch (Exception ex)
            {
                //Retorna uma mensagem de BadRequest mais a mensagem de erro.
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }        
    }
}