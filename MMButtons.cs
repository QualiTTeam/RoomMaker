using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MMButtons : MonoBehaviour {

	public Button st;
	public Button ex;

	public void Empezar(){

		SceneManager.LoadScene ("Scene_App");

	}

	public void Exit(){


		Application.Quit ();

	}

	// Use this for initialization
	void Start () {

		st.onClick.AddListener (Empezar);
		ex.onClick.AddListener (Exit);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
