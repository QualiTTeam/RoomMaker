using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropiedadesPilar : MonoBehaviour {

	private GameObject Room;
	private Slider SldZPilarm, SldZPilarcm, SldZPilarmm, SldXPilarm, SldXPilarcm, SldXPilarmm, SldRotatePilar; 
	private Text Long, Anc, Grad;
	private Button dlt_Pilar;
	private RuntimeGizmos.TransformGizmo tg;
	private Object_Generator og;
	private int astrg;
	private float x, roty, z;

	private float AltP;

	void deletePilar(){

		if (tg.target != null) {
			
			Destroy (tg.target.gameObject);
			tg.target = null;
			og.cont = og.cont - 1;
		}

	}


	// Use this for initialization
	void Start () {

		//HABITACION
		Room = GameObject.Find("GO_Room");
		AltP = Room.transform.localScale.y;

		tg = GameObject.Find ("Orbital_Camera").GetComponent<RuntimeGizmos.TransformGizmo> ();
		og = GameObject.Find ("Master_Controller").GetComponent<Object_Generator> ();

		//EJE Z
		SldZPilarm = GameObject.Find ("Sld_Long_m_P").GetComponent<Slider> ();
		SldZPilarcm = GameObject.Find ("Sld_Long_cm_P").GetComponent<Slider> ();
		SldZPilarmm = GameObject.Find ("Sld_Long_mm_P").GetComponent<Slider> ();

		//EJE X
		SldXPilarm = GameObject.Find ("Sld_Anc_m_P").GetComponent<Slider> ();
		SldXPilarcm = GameObject.Find ("Sld_Anc_cm_P").GetComponent<Slider> ();
		SldXPilarmm = GameObject.Find ("Sld_Anc_mm_P").GetComponent<Slider> ();

		//ROTACION EJE Y
		SldRotatePilar = GameObject.Find("Sld_Rotation_P").GetComponent<Slider>();
		SldRotatePilar.value = 0f;

		//BOTON DE BORRADO

		dlt_Pilar = GameObject.Find ("btn_delete_P").GetComponent<Button>();
		dlt_Pilar.onClick.AddListener (deletePilar);

		//TEXTOS

		Long = GameObject.Find ("txt_longitud_P").GetComponent<Text> ();
		Anc = GameObject.Find ("txt_anchura_P").GetComponent<Text> ();
		Grad = GameObject.Find ("txt_numGrados_P").GetComponent<Text> ();

		astrg = 0;

	

	}

	// Update is called once per frame
	void Update () {

		if (tg.target != null) {

			if (tg.target.Equals (this.transform) && astrg == 0) {

				//INICIALIZAMOS LOS SLIDERS DE CONTROL DE LA ESCALA EN Z
				SldZPilarm.value = Mathf.FloorToInt (this.transform.localScale.z / 100f);
				SldZPilarcm.value = Mathf.FloorToInt ((this.transform.localScale.z - SldZPilarm.value * 100f));
				SldZPilarmm.value = Mathf.FloorToInt((this.transform.localScale.z - (SldZPilarm.value*100f + SldZPilarcm.value))*10f);

				//INICIALIZAMOS LOS SLIDERS DE CONTROL DE LA ESCALA EN X
				SldXPilarm.value = Mathf.FloorToInt (this.transform.localScale.x / 100f);
				SldXPilarcm.value = Mathf.FloorToInt ((this.transform.localScale.x - SldXPilarm.value * 100f));
				SldXPilarmm.value = Mathf.FloorToInt((this.transform.localScale.x - (SldXPilarm.value*100f + SldXPilarcm.value))*10f);

				//INICIALIZAMOS EL SLIDER DE ROTACION

				SldRotatePilar.value = Mathf.FloorToInt(this.transform.eulerAngles.y)/10f;

				astrg = -1;
			}

			else if (!tg.target.Equals (this.transform) && astrg == -1) {

				astrg = 0;

			}

			if (tg.target.Equals (this.transform) && astrg == -1) {

				//ACTUALIZAMOS LAS PROPIEDADES DEL OBJETO
				
				x = SldXPilarm.value * 100 + SldXPilarcm.value + SldXPilarmm.value / 10;
				z = SldZPilarm.value * 100 + SldZPilarcm.value + SldZPilarmm.value / 10;
				roty = Mathf.RoundToInt(SldRotatePilar.value*90f);

				this.transform.localScale = new Vector3 (x, this.transform.localScale.y, z);

					this.transform.eulerAngles = new Vector3 (0, roty, 0);
					Grad.text = this.transform.rotation.eulerAngles.y.ToString("#") + "º";

				if (roty == 0) {

					Grad.text = "0" + "º";
				}
				

				//ACTUALIZAMOS LAS ETIQUETAS DE MEDIDA (Textos)

				Long.text = "LONGITUD " + (this.transform.localScale.z/100f).ToString() + " m";
				Anc.text = "ANCHURA " + (this.transform.localScale.x/100f).ToString() + " m";

			}
		}

		//ALTURA DINAMICA

		AltP = Room.transform.localScale.y;

		this.transform.localScale = new Vector3 (this.transform.localScale.x, AltP*100, this.transform.localScale.z);
		this.transform.position = new Vector3 (this.transform.position.x, AltP * 100 / 2, this.transform.position.z);

		//AREA DE MOVIMIENTO



	}
		
}
