using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace polideportivo
{
    public class Equipo
    {
        private static Acceso acceso = new Acceso();

        private int id_equipo;

        public int Id_equipo
        {
            get { return id_equipo; }
            set { id_equipo = value; }
        }

        private string nombre_equipo;

        public string Nombre_equipo
        {
            get { return nombre_equipo; }
            set { nombre_equipo = value; }
        }

        public void Insertar()
        {
            /*insert into equipo (id_equipo,nombre_equipo)
             values (1,'Boca Juniors'  )*/

            acceso.Abrir();
            string sql = "insert into equipo (id_equipo,nombre_equipo) ";
            sql += " values (" + id_equipo.ToString() + ",'" + nombre_equipo + "') ";

            acceso.Escribir(sql);

            acceso.Cerrar();
        }
        public void Editar()
        {
            acceso.Abrir();
            string sql = "Update equipo set nombre_equipo='" + nombre_equipo + "'";
            sql += " where id_equipo =" + id_equipo.ToString();

            acceso.Escribir(sql);

            acceso.Cerrar();
        }

        public void Borrar()
        {
            acceso.Abrir();
            string sql = "delete from equipo ";
            sql += " where id_equipo =" + id_equipo.ToString();

            acceso.Escribir(sql);
            acceso.Cerrar();
        }

        public static List<Equipo> Listar()
        {
            List<Equipo> equipos = new List<Equipo>();
            acceso.Abrir();

            SqlDataReader lector = acceso.Leer("Select * from equipo");

            while (lector.Read())
            {
                Equipo eq = new Equipo();
                eq.id_equipo = lector.GetInt32(0);
                eq.nombre_equipo = lector["nombre_equipo"].ToString();
                equipos.Add(eq);
            }
            lector.Close();
            acceso.Cerrar();

            return equipos;

        }
    }
}