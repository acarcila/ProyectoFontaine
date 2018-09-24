using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgresoTiempo : MonoBehaviour {

	public float tiempoMaximo;
	public bool contar;
	public bool over;

	private Image imageProgreso;
	private float tiempo;

	// Use this for initialization
	void Start () {
		imageProgreso = GameObject.Find(this.gameObject.name + "/ImageProgreso").GetComponent<Image>();
		contar = false;
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(tiempo < tiempoMaximo && contar)
		{
			tiempo += Time.deltaTime;
		}else if(tiempo >= tiempoMaximo)
		{
			over = true;
		}
		imageProgreso.fillAmount = tiempo / tiempoMaximo;
	}

	public void empezarTiempo()
	{
		contar = true;
	}

	public void detenerTiempo()
	{
		contar = false;
	}
}
