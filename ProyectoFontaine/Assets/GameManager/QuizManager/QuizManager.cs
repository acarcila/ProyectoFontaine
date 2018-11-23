using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour {

	public Text textoPregunta;
	public Button botonRespuesta1;
	public Button botonRespuesta2;
	public Button botonRespuesta3;
	public Button botonRespuesta4;
	public PanelRespuesta panelRespuesta;
	private GameManager gameManager;
	private Pregunta[] preguntas;
	private static List<Pregunta> preguntasSinResponder;
	private Pregunta preguntaActual;

	private int cantidadRespuestasCorrectas;
	private float tiempo;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectsWithTag("GameController").First().GetComponent<GameManager>();
		setPreguntas(gameManager.getPreguntas());

		cantidadRespuestasCorrectas = 0;
		tiempo = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo += Time.deltaTime;
	}

	public Pregunta[] getPreguntasSinResolver()
	{
		return preguntasSinResponder.ToArray();
	}

	public void setPreguntas(Pregunta[] preguntas)
	{
		this.preguntas = preguntas;

		if(preguntasSinResponder == null || preguntasSinResponder.Count == 0)
		{
			preguntasSinResponder = preguntas.ToList();
		}

		getPreguntaAleatoria();
	}

	public Pregunta[] getPreguntas()
	{
		return preguntas;
	}

	public Pregunta getPreguntaActual()
	{
		return preguntaActual;
	}

	public void getPreguntaAleatoria()
	{
		int indexPreguntaAleatoria = Random.Range(0, preguntasSinResponder.Count);

		preguntaActual = preguntasSinResponder[indexPreguntaAleatoria];

		setElementosUI();
	}

	public void setElementosUI()
	{
		textoPregunta.text = preguntaActual.pregunta;

		botonRespuesta1.enabled = true;
		botonRespuesta2.enabled = true;
		botonRespuesta3.enabled = true;
		botonRespuesta4.enabled = true;

		botonRespuesta1.GetComponent<BotonRespuesta>().textoRespuesta = preguntaActual.opcion1.opcion;
		botonRespuesta2.GetComponent<BotonRespuesta>().textoRespuesta = preguntaActual.opcion2.opcion;
		botonRespuesta3.GetComponent<BotonRespuesta>().textoRespuesta = preguntaActual.opcion3.opcion;
		botonRespuesta4.GetComponent<BotonRespuesta>().textoRespuesta = preguntaActual.opcion4.opcion;
	}

	public void responderPregunta(int numeroRespuesta)
	{
		if(numeroRespuesta == preguntaActual.opcionCorrecta)
		{
			Debug.Log("CORRECTO");
			panelRespuesta.valorRespuesta = true;
			cantidadRespuestasCorrectas++;
		}
		else
		{
			Debug.Log("INCORRECTO");
			panelRespuesta.valorRespuesta = false;
		}

		botonRespuesta1.enabled = false;
		botonRespuesta2.enabled = false;
		botonRespuesta3.enabled = false;
		botonRespuesta4.enabled = false;
		
		panelRespuesta.GetComponent<Animator>().SetBool("Entrada", true);

		StartCoroutine(pasarALaSiguientePregunta());
	}

	IEnumerator pasarALaSiguientePregunta()
	{
		preguntasSinResponder.Remove(preguntaActual);

		yield return new WaitForSeconds(1f);

		if(preguntasSinResponder.Count > 0)
		{
			getPreguntaAleatoria();
			panelRespuesta.GetComponent<Animator>().SetBool("Entrada", false);
		}
		else
		{
			float nota = ((float)cantidadRespuestasCorrectas / preguntas.Length) * 5f;
			int tiempoSegundos = Mathf.RoundToInt(tiempo);
			gameManager.setNotaPrueba(nota);
			gameManager.setTiempoPrueba(tiempoSegundos);

			cantidadRespuestasCorrectas = 0;
			tiempo = 0f;
			setPreguntas(preguntas);

			terminarQuiz();
		}
	}

	public void terminarQuiz()
	{
		SceneManager.LoadScene("ResultScreen", LoadSceneMode.Single);
	}

	public int getMaxPreguntas()
	{
		return preguntas.Length;
	}

	public int getCantidadPreguntasSinResponder()
	{
		return preguntasSinResponder.Count;
	}
}
