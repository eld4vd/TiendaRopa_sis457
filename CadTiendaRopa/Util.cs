using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace CadTiendaRopa
{
    public class Util
    {
        // Cadena de conexión desde App.config
        public static string conexion = ConfigurationManager
            .ConnectionStrings["conexion"].ConnectionString;

        // Método para encriptar contraseñas (SHA256)
        public static string encriptar(string texto)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
            
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("x2"));
            
            return sb.ToString();
        }
    }
}