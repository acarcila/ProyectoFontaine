using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgresoCircularBehaviour : MonoBehaviour {

	public Image imageBarraProgresoCircular;
	public Text textValor;
	public float valor;
	public float valorMaximo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		imageBarraProgresoCircular.fillAmount = valor / valorMaximo;
		textValor.text = valor + "";
	}
}
