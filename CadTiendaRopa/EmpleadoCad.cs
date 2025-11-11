using System.Data;
using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class EmpleadoCad
    {
        // Validar usuario y contraseña para el login
        public Empleado validar(string usuario, string contraseña)
        {
            Empleado empleado = null;
            
            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT * FROM Empleados WHERE Usuario=@usuario AND Contraseña=@contraseña AND Eliminado=0", conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                
                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        empleado = new Empleado
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Usuario = reader.GetString(reader.GetOrdinal("Usuario")),
                            Contraseña = reader.GetString(reader.GetOrdinal("Contraseña")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                    }
                }
            }
            
            return empleado;
        }

        // Listar todos los empleados activos
        public List<Empleado> listar()
        {
            var lista = new List<Empleado>();
            
            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT * FROM Empleados WHERE Eliminado=0", conexion);
                
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var empleado = new Empleado
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Usuario = reader.GetString(reader.GetOrdinal("Usuario")),
                            Contraseña = reader.GetString(reader.GetOrdinal("Contraseña")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(empleado);
                    }
                }
            }
            
            return lista;
        }
    }
}