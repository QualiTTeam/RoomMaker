using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventary_Mng : MonoBehaviour {


	public Button btn_inventario;
	public GameObject img_inventario;
	public bool active = false;

	// Use this for initialization
	void Start () {

		active = false;

	}
	
	// Update is called once per frame
	void Update () {

			if (active == false && Input.GetKeyDown (KeyCode.E)) {

				img_inventario.SetActive (true);
				active = true;
			
			} else if (active == true && Input.GetKeyDown (KeyCode.E)) {

				img_inventario.SetActive (false);
				active = false;

			}
			
		
	}
}
