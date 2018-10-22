[System.Serializable]
public class Pregunta{
	public string pregunta;
	public new Opcion opcion1;
	public new Opcion opcion2;
	public new Opcion opcion3;
	public new Opcion opcion4;
	public int opcionCorrecta;

	public Pregunta(string pregunta, string opcion1, string opcion2, string opcion3, string opcion4, int opcionCorrecta)
	{
		this.pregunta = pregunta;
		this.opcion1 = new Opcion(opcion1, 1);
		this.opcion2 = new Opcion(opcion2, 2);
		this.opcion3 = new Opcion(opcion3, 3);
		this.opcion4 = new Opcion(opcion4, 4);
		this.opcionCorrecta = opcionCorrecta;

	}
}
