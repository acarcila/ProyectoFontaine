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
	public QuizManager quizManager;
	
	private string datosConexion;
	private MySqlConnection conexion;

	private Pregunta[] preguntas;
	// Use this for initialization
	void Start () {
		datosConexion = "Server=" + servidorBaseDatos + ";Database=" + nombreBaseDatos + ";Uid=" + usuarioBaseDatos + ";Pwd=" + contraseniaBaseDatos + ";";

		conectarServidorBD();

		MySqlDataReader resultado = select("`preguntas`");
		DataTable tabla = new DataTable();
		tabla.Load(resultado);
		
		preguntas = new Pregunta[tabla.Rows.Count];

		// foreach(DataRow row in tabla.Rows)
		// {
		for(int i = 0; i < tabla.Rows.Count; i++)
		{
			DataRow row = tabla.Rows[i];
			string pregunta = row["pregunta"].ToString();
			string opcion1 = row["opcion1"].ToString();
			string opcion2 = row["opcion2"].ToString();
			string opcion3 = row["opcion3"].ToString();
			string opcion4 = row["opcion4"].ToString();
			int opcionCorrecta = int.Parse(row["opcion_correcta"].ToString());

			preguntas[i] = new Pregunta(pregunta, opcion1, opcion2, opcion3, opcion4, opcionCorrecta);
		}

		quizManager.setPreguntas(preguntas);

		resultado.Close();

		
		
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
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
