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
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public string servidorBaseDatos;
	public string nombreBaseDatos;
	public string usuarioBaseDatos;
	public string contraseniaBaseDatos;
	
	private string datosConexion;
	private MySqlConnection conexion;

	private Pregunta[] preguntas;
	private String scene;

	private Estudiante estudiante;
	
	private float notaPrueba;
	private int tiempoPrueba;
	// Use this for initialization

	public GameManager(string servidorBaseDatos, string nombreBaseDatos, string usuarioBaseDatos, string contraseniaBaseDatos)
	{
		this.servidorBaseDatos = servidorBaseDatos;
		this.nombreBaseDatos = nombreBaseDatos;
		this.usuarioBaseDatos = usuarioBaseDatos;
		this.contraseniaBaseDatos = contraseniaBaseDatos;
	}

	void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
	void Start () {				
		conectarServidorBD();

		getPreguntasFromBD();		
	}

	void Update()
	{
		scene = SceneManager.GetActiveScene().name;
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	
	public bool conectarServidorBD()
	{
		datosConexion = "Server=" + servidorBaseDatos + ";Database=" + nombreBaseDatos + ";Uid=" + usuarioBaseDatos + ";Pwd=" + contraseniaBaseDatos + ";";
		conexion = new MySqlConnection(datosConexion);

		try
		{
			conexion.Open();
			Debug.Log("Conexión exitosa con la base de datos");
			return true;
		}catch(MySqlException ex)
		{
			Debug.LogError("Imposible conextarse a la Base de Datos: " + ex);
			return false;
		}
	}

	public void getPreguntasFromBD()
	{
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
		
		resultado.Close();
	}

	public bool getEstudiante(string idEstudiante)
	{
		MySqlDataReader resultado = select("`usuarios` WHERE identificacion='" + idEstudiante + "'");
		DataTable tabla = new DataTable();
		tabla.Load(resultado);

		// foreach(DataRow row in tabla.Rows)
		// {
		for(int i = 0; i < tabla.Rows.Count; i++)
		{
			DataRow row = tabla.Rows[i];
			string identificacion = row["identificacion"].ToString();
			string nombre = row["nombre"].ToString();
			string apellido = row["apellido"].ToString();

			estudiante = new Estudiante(identificacion, nombre, apellido);
		}
		
		resultado.Close();

		return tabla.Rows.Count > 0;
	}

	public Calificacion[] getRespuestas()
	{
		// MySqlDataReader resultado = select("`respuestas` WHERE estudiante_id=" + estudiante.idEstudiante);
		MySqlDataReader resultado = select("`respuestas` WHERE estudiante_id=" + 1234);
		DataTable tabla = new DataTable();
		tabla.Load(resultado);

		Calificacion[] calificacion = new Calificacion[tabla.Rows.Count];
		// foreach(DataRow row in tabla.Rows)
		// {
		for(int i = 0; i < tabla.Rows.Count; i++)
		{
			DataRow row = tabla.Rows[i];
			int idCalificacion = 0;
    		int idPregunta = 0;
    		// string idEstudiante = estudiante.idEstudiante;
			string idEstudiante = "1234";
			float nota = float.Parse(row["nota"].ToString());
			int tiempo = int.Parse(row["tiempo"].ToString());

			calificacion[i] = new Calificacion(idCalificacion, idPregunta, idEstudiante, nota, tiempo);
		}
		
		resultado.Close();

		return calificacion;
	}

	public void setScene(string scene)
	{
		this.scene = scene;
	}

	public MySqlDataReader select(string selectInfo)
	{
		MySqlCommand cmd = conexion.CreateCommand();
		cmd.CommandText = "SELECT * FROM " + selectInfo;
		MySqlDataReader resultado = cmd.ExecuteReader();

		return resultado;
	}

	public void insertRespuesta(string estudianteID, float nota, int tiempo)
	{
		MySqlCommand cmd = conexion.CreateCommand();
		cmd.CommandText = "INSERT INTO `respuestas`(`estudiante_id`, `nota`, `tiempo`) VALUES (" + estudianteID + "," + nota + "," + tiempo + ")";
		MySqlDataReader resultado = cmd.ExecuteReader();
		resultado.Close();
	}

	public void subirRespuesta(float nota, int tiempo)
	{
		insertRespuesta(estudiante.idEstudiante, nota, tiempo);
	}

	public Pregunta[] getPreguntas()
	{
		return preguntas;
	}

	public float getNotaPrueba()
	{
		return notaPrueba;
	}

	public void setNotaPrueba(float notaPrueba)
	{
		this.notaPrueba = notaPrueba;
	}

	public int getTiempoPrueba()
	{
		return tiempoPrueba;
	}

	public void setTiempoPrueba(int tiempoPrueba)
	{
		this.tiempoPrueba = tiempoPrueba;
	}

	public static void actionButtonSalir()
	{
		Application.Quit();
	}
}
