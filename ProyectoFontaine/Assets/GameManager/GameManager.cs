using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.Common;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

using UnityEngine;

public class GameManager : MonoBehaviour {

	public string servidorBaseDatos;
	public string nombreBaseDatos;
	public string usuarioBaseDatos;
	public string contraseniaBaseDatos;
	
	private string datosConexion;
	private MySqlConnection conexion;
	// Use this for initialization
	void Start () {
		datosConexion = "Server=" + servidorBaseDatos + ";Database=" + nombreBaseDatos + ";Uid=" + usuarioBaseDatos + ";Pwd=" + contraseniaBaseDatos + ";";

		conectarServidorBD();

		MySqlDataReader resultado = select("`preguntas`");
		DataTable tabla = new DataTable();
		tabla.Load(resultado);
		
		foreach(DataRow row in tabla.Rows)
		{
			Debug.Log(row["pregunta"].ToString());
		}

		resultado.Close();

		
	}
	
	private void conectarServidorBD()
	{
		conexion = new MySqlConnection(datosConexion);

		try
		{
			conexion.Open();
			Debug.Log("Conexión exitosa con la base de datos");
		}catch(MySqlException ex)
		{
			Debug.LogError("Imposible conextarse a la Base de Datos: " + ex);
		}
	}

	public MySqlDataReader select(string selectInfo)
	{
		MySqlCommand cmd = conexion.CreateCommand();
		cmd.CommandText = "SELECT * FROM " + selectInfo;
		MySqlDataReader resultado = cmd.ExecuteReader();

		return resultado;
	}
}
