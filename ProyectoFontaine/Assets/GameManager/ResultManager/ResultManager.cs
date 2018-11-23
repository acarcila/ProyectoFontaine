using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResultManager : MonoBehaviour {

	public BarraProgresoCircularBehaviour imageBarraProgreso;
	public Text textTiempo;

	private GameManager gameManager;
	private Estudiante estudiante;

	private float notaPrueba;
	private int tiempoPrueba;

    // Use this for initialization
    void Start () {
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
		notaPrueba = gameManager.getNotaPrueba();
		gameManager.setNotaPrueba(0f);
		tiempoPrueba = gameManager.getTiempoPrueba();
		gameManager.setTiempoPrueba(0);

		// notaPrueba = 4f;
		// tiempoPrueba = 300;

		imageBarraProgreso.valor = notaPrueba;
		imageBarraProgreso.valorMaximo = 5f;

		int minutos = (int)(tiempoPrueba/60);
		int segundos = (int)(tiempoPrueba - (minutos * 60));
		textTiempo.text = minutos + ":" + segundos + " minutos";

		gameManager.subirRespuesta(notaPrueba, tiempoPrueba);
	}

	public void actionButtonVolverAIntentar()
	{
		SceneManager.LoadScene("QuizScreen", LoadSceneMode.Single);
	}

	public void actionButtonContinuar()
	{
		SceneManager.LoadScene("IndexScreen", LoadSceneMode.Single);
	}
}
