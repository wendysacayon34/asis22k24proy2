﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class sentencias
    {

        conexion cn = new conexion();
        //mostrar los datos en DataGridView de forma DESC y que tengan estado 1 =>Randy 
        public OdbcDataAdapter llenaTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            string[] camposDesc = obtenerCampos(tabla); //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + " WHERE estado=0 || estado=1 ORDER BY " + camposDesc[0] + " DESC ;";
            //SELECT * FROM tbl_bodega WHERE estado=1 ORDER BY kbodega DESC
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.probarConexion());
            return dataTable;
<<<<<<< HEAD
=======
         
>>>>>>> 02293b4e4c9a08e4ab664b7e11dd6d970c0f3e70
        }
        //obtener ID siguiente => Randy             
        public string obtenerId(string tabla)
        {
            string[] camposDesc = obtenerCampos(tabla); //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT MAX(" + camposDesc[0] + ") FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`            
            string sid = "";
            OdbcCommand command = new OdbcCommand(sql, cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (reader.GetValue(0).ToString() == null || reader.GetValue(0).ToString() == "")
                    {
                        sid = "1";
                    }
                    else
                    {
                        sid = reader.GetValue(0).ToString();
                    }
                }
            }
            else
            {
                sid = "1";
            }
            return sid;
        }
        //obtener la ultima columna de la funcion DESCRIBE => Randy 
        public string[] obtenerExtra(string tabla)//metodo que obtiene la lista de los valores EXTRA que tiene un campo
        {
            string[] Campos = new string[30];
            int i = 0;
            OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Campos[i] = reader.GetValue(5).ToString();
                i++;
            }
            return Campos;// devuelve un arreglo con los valores EXTRA
        }

        /**/
        public OdbcDataAdapter llenaTbl2()// metodo  que obtinene el contenio de una tabla
        {
            string sql = "SELECT Id_ayuda, Ruta, indice FROM ayuda";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.probarConexion());
            return dataTable;
        }
        /**/

        public int contarAlias(string tabla)// metodo  que obtinene el contenio de una tabla
        {
           int Campos = 0;
            
            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos++;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtenerTipo, revise los parámetros de la tabla  \n -" + tabla.ToUpper() + "\n -"); }
            return Campos;// devuelve un arreglo con los tiposlos campos
        }


        public int contarReg(string idindice)// metodo  que obtinene el contenio de una tabla
        {
            int Campos = 0;
            try
            {
                OdbcCommand command = new OdbcCommand("SELECT * FROM ayuda WHERE id_ayuda = " + idindice + ";", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos++;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtenerTipo, revise los parámetros de la tabla  \n -" + idindice.ToUpper() + "\n -"); }
            return Campos;// devuelve un arreglo con los tiposlos campos
        }
        public string primerCampo(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            string Campos ="";

            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                reader.Read();

                    Campos = reader.GetValue(0).ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtenerTipo, revise los parámetros de la tabla  \n -" + tabla.ToUpper() + "\n -"); }
            return Campos;// devuelve un arreglo con los tipos de campos
        }       

        public string modRuta(string idindice)// metodo  que obtinene el contenio de una tabla
        {


            string indice2 = " ";
            OdbcCommand command = new OdbcCommand("SELECT * FROM ayuda Where id_ayuda=" + idindice + ";", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                indice2 = reader.GetValue(1).ToString();

            }
            return indice2;// devuelve un arrgeglo con los campos


        }
		public string rutaReporte(string idindice)// metodo  que obtinene el contenio de una tabla
		{


			string indice2 = " ";
			OdbcCommand command = new OdbcCommand("SELECT * FROM reportes WHERE Id_reporte = " + idindice + " ;", cn.probarConexion());
			OdbcDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				indice2 = reader.GetValue(1).ToString();

			}
			return indice2;// devuelve un arrgeglo con los campos


		}
		public string modIndice(string idindice)// metodo  que obtinene el contenio de una tabla
        {


            string indice = " ";
            OdbcCommand command = new OdbcCommand("SELECT * FROM ayuda WHERE id_ayuda = " + idindice + ";", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                indice = reader.GetValue(2).ToString();
            }


            return indice;// devuelve un arrgeglo con los campos


        }

/*
        public string VerificacionR(string idindice)// metodo  que obtinene el contenio de una tabla
        {

          
            string indice = " ";

            OdbcCommand command = new OdbcCommand("SELECT COUNT(*) FROM ayuda", cn.probarConexion());
            //OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                indice = reader.GetValue(0).ToString();
            }
    

            return indice;// devuelve un arrgeglo con los campos
           
        }
        
*/

        public string ProbarTabla(string tabla)
        {
            string error = "";
            try
            {
                OdbcCommand command = new OdbcCommand("SELECT * FROM " + tabla + ";", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
            }
            catch (Exception)
            {
                error = "La tabla " + tabla.ToUpper() + " no existe.";
            }
            return error;
        }

        public string ProbarEstado(string tabla)
        {
            string error = "";
            try
            {
                OdbcCommand command = new OdbcCommand("SELECT estado FROM " + tabla + ";", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
            }
            catch (Exception)
            {

                error = "La tabla " + tabla.ToUpper() + " no contiene el campo de ESTADO";
            }

            return error;
        }
        public int ProbarRegistros(string tabla)
        {
            int registros =0;
            try
            {
                OdbcCommand command = new OdbcCommand("SELECT * FROM " + tabla + " where estado=1;", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    registros++;
                }
            }
            catch (Exception)
            {

            }

            return registros;
        }

        public string[] obtenerCampos(string tabla)
        {
            string[] Campos = new string[30];
            int i = 0;
            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos[i] = reader.GetValue(0).ToString();  // Obtenemos el nombre de la columna
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parámetros \n -" + tabla);
            }
            return Campos;  // Devolver un arreglo con los nombres de las columnas
        }


        public List<(string nombreColumna, bool esAutoIncremental, bool esClaveForanea)> obtenerColumnasYPropiedades(string nombreTabla)
        {
            List<(string, bool, bool)> columnas = new List<(string, bool, bool)>();

            try
            {
                // Paso 1: Obtener las columnas y propiedades (como autoincremental)
                string queryColumnas = $"SHOW COLUMNS FROM {nombreTabla};";
                OdbcCommand comando = new OdbcCommand(queryColumnas, cn.probarConexion());
                OdbcDataReader lector = comando.ExecuteReader();

                // Crear un diccionario para almacenar las claves foráneas
                HashSet<string> clavesForaneas = new HashSet<string>();

                // Paso 2: Obtener las claves foráneas de la tabla desde INFORMATION_SCHEMA
                string queryClavesForaneas = $@"
                    SELECT COLUMN_NAME
                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                    WHERE TABLE_NAME = '{nombreTabla}' AND REFERENCED_TABLE_NAME IS NOT NULL;";
                OdbcCommand comandoClaves = new OdbcCommand(queryClavesForaneas, cn.probarConexion());
                OdbcDataReader lectorClaves = comandoClaves.ExecuteReader();

                while (lectorClaves.Read())
                {
                    string nombreColumnaForanea = lectorClaves.GetString(0);
                    clavesForaneas.Add(nombreColumnaForanea);  // Añadir la clave foránea al conjunto
                }

                lectorClaves.Close();

                // Paso 3: Procesar las columnas y determinar si son autoincrementales o claves foráneas
                while (lector.Read())
                {
                    string nombreColumna = lector.GetString(0);  // Nombre de la columna
                    string columnaExtra = lector.GetString(5);   // Información adicional (e.g. AUTO_INCREMENT)

                    bool esAutoIncremental = columnaExtra.Contains("auto_increment");  // Detectar si es autoincremental
                    bool esClaveForanea = clavesForaneas.Contains(nombreColumna);  // Detectar si es clave foránea

                    // Añadir la columna con sus propiedades a la lista
                    columnas.Add((nombreColumna, esAutoIncremental, esClaveForanea));
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener columnas: " + ex.Message);
            }

            return columnas;
        }


        public void ejecutarQueryConTransaccion(List<string> queries)
        {
            OdbcConnection connection = cn.probarConexion();
            OdbcTransaction transaction = null;

            try
            {
                // Iniciar la transacción
                transaction = connection.BeginTransaction();

                foreach (string query in queries)
                {
                    OdbcCommand command = new OdbcCommand(query, connection, transaction);
                    command.ExecuteNonQuery();
                }

                // Confirmar la transacción
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Si algo falla, revertir los cambios
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                Console.WriteLine("Error en la transacción: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public string[] ObtenerTipo(string tabla)//metodo que obtiene la lista de los tipos de campos que requiere una tabla
        {
            string[] Campos = new string[30];
            int i = 0;
            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos[i] = limpiarTipo(reader.GetValue(1).ToString());
                    i++;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtenerTipo, revise los parametros de la tabla  \n -" + tabla.ToUpper() + "\n -"); }
            return Campos;// devuelve un arreglo con los tipos
        }
        public string[] obtenerLLave(string tabla)//metodo que obtiene la lista de los tipos de campos que requiere una tabla
        {
            string[] Campos = new string[30];
            int i = 0;
            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos[i] = reader.GetValue(3).ToString();
                    i++;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtenerTipo, revise los parametros de la tabla  \n -" + tabla + "\n -"); }

            return Campos;// devuelve un arreglo con los tipos
        }
        public Dictionary<string, string> obtenerItems(string tabla, string campoClave, string campoDisplay)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            try
            {
                OdbcCommand command = new OdbcCommand($"SELECT {campoClave}, {campoDisplay} FROM {tabla} WHERE estado = 1", cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());  // id_raza -> nombre_raza
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nError en obtenerItems, revise los parámetros \n -" + tabla + "\n -" + campoClave);
            }
            return items;
        }

        string limpiarTipo(string cadena)// elimina los parentesis y tama;o de campo del tipo de campo
        {
            bool dim = false;
            string nuevaCadena = "";


            for (int j = 0; j < cadena.Length; j++)
            {
                if (cadena[j] == '(') { dim = true; }
            }

            if (dim == true)
            {
                int i = 0;

                int tam = cadena.Length;

                while (cadena[i] != '(')
                {
                    nuevaCadena += cadena[i];
                    i++;
                }

            }
            else
            {
                return cadena;
            }

            return nuevaCadena;// devuelve la cadena unicamente con el tipo
        }

		public string llaveCampo(string tabla, string campo, string valor)
		{
			string llave = "";
			try
			{
				OdbcCommand command = new OdbcCommand("SELECT * FROM " + tabla + " where "+campo+" = '"+valor+"' ;", cn.probarConexion());
				OdbcDataReader reader = command.ExecuteReader();
				reader.Read();
				llave = reader.GetValue(0).ToString();
			}
			catch (Exception)
			{
				
			}
			return llave;
		}
		public string llaveCampoReverso(string tabla, string campo, string valor)
		{
			string llave = "";
			string[] Campos = obtenerCampos(tabla);
			try
			{
				OdbcCommand command = new OdbcCommand("SELECT "+campo+" FROM " + tabla + " where " + Campos[0]+ " = " + valor + " ;", cn.probarConexion());
				OdbcDataReader reader = command.ExecuteReader();
				reader.Read();
				llave = reader.GetValue(0).ToString();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Dio errore " + "SELECT " + campo + " FROM " + tabla + " where " + campo + " = " + valor + " ;" + ex.ToString());
			}
			return llave;
		}

		public string IdModulo(string aplicacion)
		{
			string llave = "";
			try
			{
				OdbcCommand command = new OdbcCommand("SELECT * FROM tbl_aplicacion" + " where" + " PK_id_aplicacion= " +aplicacion + " ;", cn.probarConexion());
				OdbcDataReader reader = command.ExecuteReader();
				reader.Read();
				llave = reader.GetValue(0).ToString();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Dio errore " + "SELECT * FROM tbl_aplicacion" + " where" + " PK_id_aplicacion= " + aplicacion + " ;" +ex.ToString());
			}
			return llave;
		}

		public void ejecutarQuery(string query)// ejecuta un query en la BD
        {
            try
            {
                OdbcCommand consulta = new OdbcCommand(query, cn.probarConexion());
                consulta.ExecuteNonQuery();
            }
            catch (OdbcException ex) { Console.WriteLine(ex.ToString()); }

        }

      

        // Método para insertar en la tabla "factura"
      

        // Método para manejar ambas inserciones
    }
}
