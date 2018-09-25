using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonRespuesta : MonoBehaviour {

    public string textoRespuesta;
    public int numero;

    private Text textoBoton;

	// Use this for initialization
	void Start () {
        actualizarValores();
	}
	
	// Update is called once per frame
	void Update () {
		actualizarValores();
	}

    public void actualizarValores()
    {
        textoBoton = GetComponentInChildren<Text>();
        textoBoton.text = textoRespuesta;
    }
}
