using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuObjSeleccionado : MonoBehaviour {

	RuntimeGizmos.TransformGizmo tg;
	public GameObject intfPilar;
	GameObject intfObject;
	GameObject intfRoom;

	// Use this for initialization
	void Start () {

		tg = GameObject.Find ("Orbital_Camera").GetComponent<RuntimeGizmos.TransformGizmo> ();
		intfPilar = GameObject.Find ("Pilar_Intf");
		intfRoom = GameObject.Find ("Size_Room_Sliders");
		intfObject = GameObject.Find("Mueble_Intf");


		//INICIALIZAMOS EL ESTADO DE LOS ELEMENTOS
		intfPilar.SetActive (true);
		intfPilar.transform.localScale = new Vector3(0, 0, 0);

		intfRoom.SetActive (true);
		intfObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (tg.target == null) {

			intfRoom.SetActive (true);

			//Interfaz de pilar
			intfPilar.SetActive (true);
			intfPilar.transform.localScale = new Vector3 (0, 0, 0);


			intfObject.SetActive (false);

		} else if (tg.target.tag == "Pilar") {

			intfRoom.SetActive (false);


			intfPilar.SetActive (true);
			intfPilar.transform.localScale = new Vector3 (1, 1, 1);
	


			intfObject.SetActive (false);

		} else if(tg.target!=null && tg.target.tag == "Mueble"){

			intfRoom.SetActive (false);

			//Interfaz de pilar
			intfPilar.SetActive (true);
			intfPilar.transform.localScale = new Vector3 (0, 0, 0);


			intfObject.SetActive (true);

		}

	}
}
