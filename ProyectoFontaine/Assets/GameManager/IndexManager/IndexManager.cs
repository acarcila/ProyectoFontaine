using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndexManager : MonoBehaviour {

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();		
	}

	public void actionButtonCalificaciones()
	{
		SceneManager.LoadScene("CalificationsScreen", LoadSceneMode.Single);
	}

}
