using System;
using System.Text;
using System.Security.Cryptography;
using AgilizaRH.Context;
using AgilizaRH.Models;

namespace AgilizaRH.Helper
{
    public class Tools
    {
        AgilizaRHContext _context = new AgilizaRHContext();

        public string Criptografar(string text)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(text);

                SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

                return hash;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public void MontaLog(int telaId, string descricao, int? usuarioId, string acao)
        {
            Log l = new Log();
            l.Data = DateTime.Now;
            l.TelaId = telaId;
            l.Descricao = descricao;
            l.UsuarioId = (int)usuarioId;
            l.Acao = acao;

            try
            {
                _context.Log.Add(l);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                l = new Log();
                l.Data = DateTime.Now;
                l.TelaId = telaId;
                l.Descricao = "ERRO AO SALVAR LOG " + ex.Message;
                l.UsuarioId = (int)usuarioId;
                l.Acao = "ERRO";

                _context.Log.Add(l);
                _context.SaveChanges();
            }
        }
    }
}
