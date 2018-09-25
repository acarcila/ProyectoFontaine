using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgresoTiempo : MonoBehaviour {

	public int numeroPreguntasMaximo;
    public int numeroPreguntas;
	public bool over;

    private Image imageProgreso;

	// Use this for initialization
	void Start () {
		imageProgreso = GameObject.Find(this.gameObject.name + "/ImageProgreso").GetComponent<Image>();
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (numeroPreguntas >= numeroPreguntasMaximo)
        {
            over = true;
        }
        else
        {
            over = false;
        }

		imageProgreso.fillAmount = ((float)numeroPreguntas / numeroPreguntasMaximo);
	}

    public void aumentarPregunta()
    {
        if (numeroPreguntas < numeroPreguntasMaximo)
        {
            numeroPreguntas++;
        }
    }
}
