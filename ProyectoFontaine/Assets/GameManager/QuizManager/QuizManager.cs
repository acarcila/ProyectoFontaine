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
	private Pregunta[] preguntas;
	private static List<Pregunta> preguntasSinResponder;
	private Pregunta preguntaActual;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setPreguntas(Pregunta[] preguntas)
	{
		this.preguntas = preguntas;

		if(preguntasSinResponder == null)
		{
			preguntasSinResponder = preguntas.ToList();
		}

		getPreguntaAleatoria();
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
	}
}
