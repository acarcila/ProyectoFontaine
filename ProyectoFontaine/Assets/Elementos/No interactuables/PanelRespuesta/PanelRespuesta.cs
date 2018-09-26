using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRespuesta : MonoBehaviour {

	public bool valorRespuesta;
	public Color colorRespuestaCorrecta;
	public Color colorRespuestaIncorrecta;
	public string textoRespuestaCorrecta;
	public string textoRespuestaIncorrecta;
	private Text textoValorRespuesta;
	
	void Start () {
		textoValorRespuesta = GetComponentInChildren<Text>();
	}
	// Update is called once per frame
	void Update () {
		actualizarElementosUI();
	}

	public void actualizarElementosUI()
	{
		if(valorRespuesta)
		{
			GetComponent<Image>().color = colorRespuestaCorrecta;
			textoValorRespuesta.text = textoRespuestaCorrecta;
		}
		else
		{
			GetComponent<Image>().color = colorRespuestaIncorrecta;
			textoValorRespuesta.text = textoRespuestaIncorrecta;
		}
	}
}
