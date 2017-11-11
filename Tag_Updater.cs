using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tag_Updater : MonoBehaviour {

	public UnityEngine.UI.Text Longitud;
	public UnityEngine.UI.Text Anchura;
	public UnityEngine.UI.Text Altura;
	public UnityEngine.UI.Text Rango;
	public UnityEngine.UI.Text Intensidad;

	public Slider Range;
	public Slider Intensity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Longitud.text = "LONGITUD " + transform.localScale.x.ToString () + " m";
		Anchura.text = "ANCHURA " + transform.localScale.z.ToString () + " m";
		Altura.text = "ALTURA " + transform.localScale.y.ToString () + " m";

		Rango.text = "RANGO " + Range.value;
		Intensidad.text = "INTENSIDAD " + Intensity.value;
	}
}
