using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropiedadesMueble : MonoBehaviour {


	private Slider SldRotateMueble; 
	private Text Grad;
	private Button dlt_Mueble;
	private RuntimeGizmos.TransformGizmo tg;
	private Object_Generator og;
	private int astrg;
	private float roty;

	void deleteMueble(){

		if (tg.target != null) {

			Destroy (tg.target.gameObject);
			tg.target = null;
			og.cont = og.cont - 1;
		}

	}


	// Use this for initialization
	void Start () {

		//SCRIPTS

		tg = GameObject.Find ("Orbital_Camera").GetComponent<RuntimeGizmos.TransformGizmo> ();
		og = GameObject.Find ("Master_Controller").GetComponent<Object_Generator> ();


		//TEXTO

		Grad = GameObject.Find ("txt_numGrados_M").GetComponent<Text> ();

		//ROTACION EJE Y
		SldRotateMueble = GameObject.Find("Sld_Rotation_M").GetComponent<Slider>();
		SldRotateMueble.value = 0f;

		//BORRAR MUEBLE
		dlt_Mueble = GameObject.Find ("btn_delete_M").GetComponent<Button>();
		dlt_Mueble.onClick.AddListener (deleteMueble);


		astrg = 0;

	}

	// Update is called once per frame
	void Update () {

		if (tg.target != null) {

			if (tg.target.Equals (this.transform) && astrg == 0) {

				//INICIALIZAMOS EL SLIDER DE ROTACION

				SldRotateMueble.value = Mathf.FloorToInt(this.transform.eulerAngles.y)/10f;

				astrg = -1;
			}

			else if (!tg.target.Equals (this.transform) && astrg == -1) {

				astrg = 0;

			}

			if (tg.target.Equals (this.transform) && astrg == -1) {

				//ACTUALIZAMOS LAS PROPIEDADES DEL OBJETO

				roty = Mathf.RoundToInt(SldRotateMueble.value*10.0f);

					this.transform.eulerAngles = new Vector3 (0, roty, 0);
					Grad.text = roty.ToString() + "º";

			}
		}

	}

}
