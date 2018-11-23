using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoginManager : MonoBehaviour {

	public InputField inputFieldIdentificacion;

	private GameManager gameManager;
	private Estudiante estudiante;

    // Use this for initialization
    void Start () {
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void actionButtonIngresar()
	{
		string identificacion = inputFieldIdentificacion.text;

		if(gameManager.getEstudiante(identificacion))
		{
			SceneManager.LoadScene("IndexScreen", LoadSceneMode.Single);
		}
		else
		{
			Debug.Log("Estudiante no encontrado");
		}
	}
}
