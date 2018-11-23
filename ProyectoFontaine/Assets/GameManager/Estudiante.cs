[System.Serializable]
public class Estudiante{
	public string idEstudiante;
	public string nombreEstudiante;
	public string apellidoEstudiante;

	public Estudiante(string idEstudiante, string nombreEstudiante, string apellidoEstudiante)
	{
		this.idEstudiante = idEstudiante;
		this.nombreEstudiante = nombreEstudiante;
		this.apellidoEstudiante = apellidoEstudiante;
	}
}
