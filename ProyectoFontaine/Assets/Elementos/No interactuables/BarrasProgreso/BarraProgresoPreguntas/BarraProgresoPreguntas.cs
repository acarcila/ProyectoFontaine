using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgresoPreguntas : MonoBehaviour {

    public QuizManager quizManager;
	public bool over;

    private Image imageProgreso;

    private int numeroPreguntasMaximo;
    private int numeroPreguntas;

	// Use this for initialization
	void Start () {
		imageProgreso = GameObject.Find(this.gameObject.name + "/ImageProgreso").GetComponent<Image>();
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
        numeroPreguntasMaximo = quizManager.getMaxPreguntas();
        numeroPreguntas = quizManager.getCantidadPreguntasSinResponder();
        
        if (numeroPreguntas >= numeroPreguntasMaximo)
        {
            over = true;
        }
        else
        {
            over = false;
        }

		imageProgreso.fillAmount = ((float)(numeroPreguntasMaximo-numeroPreguntas) / numeroPreguntasMaximo);
	}

    public void aumentarPregunta()
    {
        if (numeroPreguntas < numeroPreguntasMaximo)
        {
            numeroPreguntas++;
        }
    }
}
