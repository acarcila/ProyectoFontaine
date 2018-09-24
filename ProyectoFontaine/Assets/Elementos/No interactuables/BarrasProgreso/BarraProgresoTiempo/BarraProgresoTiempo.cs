using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgresoTiempo : MonoBehaviour {

	public int numeroPreguntaMaxima;
    public float numeroPreguntaActual;
	public bool over;

	private Image imageProgreso;
	
	// Use this for initialization
	void Start () {
		imageProgreso = GameObject.Find(this.gameObject.name + "/ImageProgreso").GetComponent<Image>();
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (numeroPreguntaActual >= numeroPreguntaMaxima)
        {
            over = true;
        }
        else
        {
            over = false;
        }
		imageProgreso.fillAmount = numeroPreguntaActual / numeroPreguntaMaxima;
	}

    public void aumentarPregunta()
    {
        if (numeroPreguntaActual < numeroPreguntaMaxima)
        {
            numeroPreguntaActual++;
        }
    }
}
