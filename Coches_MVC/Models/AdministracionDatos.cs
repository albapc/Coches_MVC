using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Coches_MVC.Models
{
    public class AdministracionDatos
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int AltaClientes(Persona cli)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into dbo.Clientes (NIF, nombre, apellidos, telefono, direccion, email) values (@NIF, @nombre, @apellidos, @telefono, @direccion, @email)", con);
            comando.Parameters.Add("@NIF", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);

            comando.Parameters["@NIF"].Value = cli.NIF;
            comando.Parameters["@nombre"].Value = cli.Nombre;
            comando.Parameters["@apellidos"].Value = cli.Apellidos;
            comando.Parameters["@telefono"].Value = cli.Telefono;
            comando.Parameters["@direccion"].Value = cli.Direccion;
            comando.Parameters["@email"].Value = cli.Email;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int AltaEmpleados(Persona emp)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into dbo.Empleados (NIF, nombre, apellidos, telefono, direccion, email) values (@NIF, @nombre, @apellidos, @telefono, @direccion, @email)", con);
            comando.Parameters.Add("@NIF", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);

            comando.Parameters["@NIF"].Value = emp.NIF;
            comando.Parameters["@nombre"].Value = emp.Nombre;
            comando.Parameters["@apellidos"].Value = emp.Apellidos;
            comando.Parameters["@telefono"].Value = emp.Telefono;
            comando.Parameters["@direccion"].Value = emp.Direccion;
            comando.Parameters["@email"].Value = emp.Email;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int AltaOperaciones(Operacion ope)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into dbo.Operacion (fecha, tipo, ID_empleado, ID_cliente, precio, ID_vehiculo) values (@fecha, @tipo, @ID_empleado, @ID_cliente, @precio, @ID_vehiculo)", con);

            comando.Parameters.Add("@fecha", SqlDbType.Date);
            comando.Parameters.Add("@tipo", SqlDbType.VarChar);
            comando.Parameters.Add("@ID_empleado", SqlDbType.Int);
            comando.Parameters.Add("@ID_cliente", SqlDbType.Int);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters.Add("@ID_vehiculo", SqlDbType.Int);

            comando.Parameters["@fecha"].Value = ope.Fecha;
            comando.Parameters["@tipo"].Value = ope.Tipo;
            comando.Parameters["@ID_empleado"].Value = ope.Empleado;
            comando.Parameters["@ID_cliente"].Value = ope.Cliente;
            comando.Parameters["@precio"].Value = ope.Precio;
            comando.Parameters["@ID_vehiculo"].Value = ope.Vehiculo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int ModificarClientes(Persona cli)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update dbo.Clientes set NIF=@NIF,nombre=@nombre,apellidos=@apellidos,telefono=@telefono,direccion=@direccion,email=@email where ID_Cliente=@ID_Cliente", con);
            comando.Parameters.Add("@NIF", SqlDbType.VarChar);
            comando.Parameters["@NIF"].Value = cli.NIF;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = cli.Nombre;
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters["@apellidos"].Value = cli.Apellidos;
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@telefono"].Value = cli.Telefono;
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = cli.Direccion;
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = cli.Email;
            comando.Parameters.Add("@ID_Cliente", SqlDbType.Int);
            comando.Parameters["@ID_Cliente"].Value = cli.ID_Persona;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int ModificarEmpleados(Persona emp)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update dbo.Empleados set NIF=@NIF,nombre=@nombre,apellidos=@apellidos,telefono=@telefono,direccion=@direccion,email=@email where ID_Cliente=@ID_Empleado", con);
            comando.Parameters.Add("@NIF", SqlDbType.VarChar);
            comando.Parameters["@NIF"].Value = emp.NIF;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = emp.Nombre;
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters["@apellidos"].Value = emp.Apellidos;
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@telefono"].Value = emp.Telefono;
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = emp.Direccion;
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = emp.Email;
            comando.Parameters.Add("@ID_Empleado", SqlDbType.Int);
            comando.Parameters["@ID_Empleado"].Value = emp.ID_Persona;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int ModificarVehiculos(Vehiculo veh)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update dbo.Vehiculos set marca=@marca,modelo=@modelo,numeroPuertas=@numeroPuertas,color=@color,kilometros=@kilometros,tipoVehiculo=@tipoVehiculo,garantia=@garantia,enStock=@enStock,fotografia=@fotografia where ID_Vehiculo=@ID_Vehiculo", con);

            comando.Parameters.Add("@marca", SqlDbType.VarChar);
            comando.Parameters["@marca"].Value = veh.Marca;
            comando.Parameters.Add("@modelo", SqlDbType.VarChar);
            comando.Parameters["@modelo"].Value = veh.Modelo;
            comando.Parameters.Add("@numeroPuertas", SqlDbType.Int);
            comando.Parameters["@numeroPuertas"].Value = veh.NumeroPuertas;
            comando.Parameters.Add("@color", SqlDbType.VarChar);
            comando.Parameters["@color"].Value = veh.Color;
            comando.Parameters.Add("@kilometros", SqlDbType.Real);
            comando.Parameters["@kilometros"].Value = veh.Kilometros;
            comando.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar);
            comando.Parameters["@tipoVehiculo"].Value = veh.TipoVehiculo;
            comando.Parameters.Add("@garantia", SqlDbType.Int);
            comando.Parameters["@garantia"].Value = veh.Garantia;
            comando.Parameters.Add("@enStock", SqlDbType.Bit);
            comando.Parameters["@enStock"].Value = veh.EnStock;
            comando.Parameters.Add("@fotografia", SqlDbType.Bit);
            comando.Parameters["@fotografia"].Value = veh.Fotografia;
            comando.Parameters.Add("@ID_Vehiculo", SqlDbType.Int);
            comando.Parameters["@ID_Vehiculo"].Value = veh.ID_Vehiculo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Persona> RecuperarClientes()
        {
            Conectar();
            List<Persona> clientes = new List<Persona>();

            SqlCommand com = new SqlCommand("select ID_Cliente,NIF,nombre,apellidos,telefono,direccion,email from dbo.Clientes", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Persona cli = new Persona
                {
                    ID_Persona = int.Parse(registros["ID_Cliente"].ToString()),
                    NIF = registros["NIF"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    Apellidos = registros["apellidos"].ToString(),
                    Telefono = registros["telefono"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Email = registros["email"].ToString()

                };
                clientes.Add(cli);
            }
            con.Close();
            return clientes;
        }

        public List<Persona> RecuperarEmpleados()
        {
            Conectar();
            List<Persona> empleados = new List<Persona>();

            SqlCommand com = new SqlCommand("select ID_Empleado,NIF,nombre,apellidos,telefono,email from dbo.Empleados", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Persona emp = new Persona
                {
                    ID_Persona = int.Parse(registros["ID_Empleado"].ToString()),
                    NIF = registros["NIF"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    Apellidos = registros["apellidos"].ToString(),
                    Telefono = registros["telefono"].ToString(),
                    Email = registros["email"].ToString()

                };
                empleados.Add(emp);
            }
            con.Close();
            return empleados;
        }

        public List<Vehiculo> RecuperarVehiculos()
        {
            Conectar();
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            SqlCommand com = new SqlCommand("select ID_Vehiculo,marca,modelo,numeroPuertas,color,kilometros,tipoVehiculo,garantia,enStock,fotografia from dbo.Vehiculos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Vehiculo veh = new Vehiculo
                {
                    ID_Vehiculo = int.Parse(registros["ID_Vehiculo"].ToString()),
                    Marca = registros["marca"].ToString(),
                    Modelo = registros["modelo"].ToString(),
                    NumeroPuertas = int.Parse(registros["numeroPuertas"].ToString()),
                    Color = registros["color"].ToString(),
                    Kilometros = long.Parse(registros["kilometros"].ToString()),
                    TipoVehiculo = registros["tipoVehiculo"].ToString(),
                    Garantia = int.Parse(registros["garantia"].ToString()),
                    EnStock = bool.Parse(registros["enStock"].ToString()),
                    Fotografia = bool.Parse(registros["fotografia"].ToString())
                   
                };
                vehiculos.Add(veh);
            }
            con.Close();
            return vehiculos;
        }

        public List<Operacion> RecuperarOperaciones()
        {
            Conectar();
            List<Operacion> operaciones = new List<Operacion>();

            SqlCommand com = new SqlCommand("select ID_Operacion,fecha,tipo,ID_empleado,ID_cliente,precio,ID_vehiculo from dbo.Operacion", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Operacion ope = new Operacion
                {
                    ID_Operacion = int.Parse(registros["ID_Operacion"].ToString()),
                    Fecha = DateTime.Parse(registros["fecha"].ToString()),
                    Tipo = registros["tipo"].ToString(),
                    Empleado = int.Parse(registros["ID_empleado"].ToString()),
                    Cliente = int.Parse(registros["ID_cliente"].ToString()),
                    Precio = float.Parse(registros["precio"].ToString()),
                    Vehiculo = int.Parse(registros["ID_vehiculo"].ToString())
                };
                operaciones.Add(ope);
            }
            con.Close();
            return operaciones;
        }

        public Persona SelectCliente(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select ID_Cliente, NIF, nombre, apellidos, telefono, direccion, email from dbo.Clientes where ID_Cliente=@ID_Cliente", con);
            comando.Parameters.Add("@ID_Cliente", SqlDbType.Int);
            comando.Parameters["@ID_Cliente"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Persona cliente = new Persona();
            if (registros.Read())
            {
                cliente.ID_Persona = int.Parse(registros["ID_Cliente"].ToString());
                cliente.NIF = registros["NIF"].ToString();
                cliente.Nombre = registros["nombre"].ToString();
                cliente.Apellidos = registros["apellidos"].ToString();
                cliente.Telefono = registros["telefono"].ToString();
                cliente.Direccion = registros["direccion"].ToString();
                cliente.Email = registros["email"].ToString();
            }
            con.Close();
            return cliente;
        }

        public Persona SelectEmpleado(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select ID_Empleado, NIF, nombre, apellidos, telefono, direccion, email from dbo.Empleados where ID_Empleado=@ID_Empleado", con);
            comando.Parameters.Add("@ID_Empleado", SqlDbType.Int);
            comando.Parameters["@ID_Empleado"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Persona empleado = new Persona();
            if (registros.Read())
            {
                empleado.ID_Persona = int.Parse(registros["ID_Empleado"].ToString());
                empleado.NIF = registros["NIF"].ToString();
                empleado.Nombre = registros["nombre"].ToString();
                empleado.Apellidos = registros["apellidos"].ToString();
                empleado.Telefono = registros["telefono"].ToString();
                empleado.Direccion = registros["direccion"].ToString();
                empleado.Email = registros["email"].ToString();
            }
            con.Close();
            return empleado;
        }

        public Vehiculo SelectVehiculo(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select ID_Vehiculo,marca,modelo,numeroPuertas,color,kilometros,tipoVehiculo,garantia,enStock,fotografia from dbo.Vehiculos where ID_Vehiculo=@ID_Vehiculo", con);
            comando.Parameters.Add("@ID_Vehiculo", SqlDbType.Int);
            comando.Parameters["@ID_Vehiculo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Vehiculo vehiculo = new Vehiculo();
            if (registros.Read())
            {
                vehiculo.ID_Vehiculo = int.Parse(registros["ID_Vehiculo"].ToString());
                vehiculo.Marca = registros["marca"].ToString();
                vehiculo.Modelo = registros["modelo"].ToString();
                vehiculo.NumeroPuertas = int.Parse(registros["numeroPuertas"].ToString());
                vehiculo.Color = registros["color"].ToString();
                vehiculo.Kilometros = long.Parse(registros["kilometros"].ToString());
                vehiculo.TipoVehiculo = registros["tipoVehiculo"].ToString();
                vehiculo.Garantia = int.Parse(registros["garantia"].ToString());
                vehiculo.EnStock = bool.Parse(registros["enStock"].ToString());
                vehiculo.Fotografia = bool.Parse(registros["fotografia"].ToString());
            }
            con.Close();
            return vehiculo;
        }
    }
}
