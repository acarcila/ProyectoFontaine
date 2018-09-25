using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Pregunta[] preguntas;
	private Pregunta[] preguntasSinResponder;
	private Pregunta preguntaActual;
	// Use this for initialization
	void Start () {
		if(preguntasSinResponder == null)
		{
			preguntasSinResponder = preguntas;
		}

		getPreguntaAleatoria();
		Debug.Log(preguntaActual.pregunta);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void getPreguntaAleatoria()
	{
		int indexPreguntaAleatoria = Random.Range(0, preguntasSinResponder.Length);

		preguntaActual = preguntasSinResponder[indexPreguntaAleatoria];

	}
}
