using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class EmpleadoCln
    {
        // Validar login
        public static Empleado validar(string usuario, string contraseña)
        {
            var empleado = new EmpleadoCad().validar(usuario, contraseña);
            return empleado;
        }

        // Listar empleados
        public static List<Empleado> listar()
        {
            return new EmpleadoCad().listar();
        }
    }
}