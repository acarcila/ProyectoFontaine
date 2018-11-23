using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalificationsManager : MonoBehaviour
{

	public BarraProgresoCircularBehaviour barraProgresoCalificacion;
	public BarraProgresoCircularBehaviour barraProgresoNumeroIntentos;
	public BarraProgresoCircularBehaviour barraProgresoRespuestasCorrectas;
	public BarraProgresoCircularBehaviour barraProgresoRespuestasIncorrectas;

    private GameManager gameManager;
	private Calificacion[] calificaciones;


    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

		calificaciones = gameManager.getRespuestas();

		List<Calificacion> mejoresCalificaciones = encontrarMejoresCalificaciones(calificaciones);
		Calificacion mejorcalificacion = encontrarMejoresTiemposDeCalificaciones(mejoresCalificaciones);
		barraProgresoCalificacion.valor = mejorcalificacion.nota;
		barraProgresoCalificacion.valorMaximo = 5f;

		barraProgresoNumeroIntentos.valor = calificaciones.Length;
		barraProgresoNumeroIntentos.valorMaximo = calificaciones.Length;
    }

    private List<Calificacion> encontrarMejoresCalificaciones(Calificacion[] calificaciones)
    {
		float mejorNota = 0f;
		List<Calificacion> mejoresCalificaciones = new List<Calificacion>();
        for(int i = 0; i < calificaciones.Length; i++)
		{
			if(calificaciones[i].nota > mejorNota)
			{
				mejorNota = calificaciones[i].nota;
			}
		}

		for(int i = 0; i < calificaciones.Length; i++)
		{
			if(calificaciones[i].nota == mejorNota)
			{
				mejoresCalificaciones.Add(calificaciones[i]);
			}
		}

		return mejoresCalificaciones;
    }

	private Calificacion encontrarMejoresTiemposDeCalificaciones(List<Calificacion> mejoresCalificaciones)
    {
        int mejorTiempo = mejoresCalificaciones[0].tiempo;
		Calificacion mejorTiempoCalificacion = null;
        for(int i = 0; i < calificaciones.Length; i++)
		{
			if(calificaciones[i].nota < mejorTiempo)
			{
				mejorTiempoCalificacion = calificaciones[i];
			}
		}

		return mejorTiempoCalificacion;
    }

}
