﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calificacion
{
    public int idCalificacion;
    public int idPregunta;
    public string idEstudiante;
	public float nota;
	public int tiempo;

    public Calificacion(int idCalificacion, int idPregunta, string idEstudiante, float nota, int tiempo)
    {
		this.idCalificacion = idCalificacion;
		this.idPregunta = idPregunta;
        this.idEstudiante = idEstudiante;
		this.nota = nota;
		this.tiempo = tiempo;
    }
}
