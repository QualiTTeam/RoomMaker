using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Uses : MonoBehaviour {

	public Slider Long_m, Long_cm, Long_mm;
	public float x;

	public Slider Alt_m, Alt_cm, Alt_mm;
	public float y;

	public Slider Anc_m, Anc_cm, Anc_mm;
	public float z;

	public Slider Range, Intensity;

	public Light LuzSuperior;

	// Use this for initialization
	void Start () {

		Long_m.value = 4.0f; Alt_m.value = 2.0f; Anc_m.value = 4.0f;
		Long_cm.value = 0.0f; Alt_cm.value = 50.0f; Anc_cm.value = 0.0f;
		Long_mm.value = 0.0f; Alt_mm.value = 0.0f; Anc_mm.value = 0.0f;
		x = this.transform.localScale.x;

		Range.value = 10.0f;
		Intensity.value = 50.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		x = Long_m.value + Long_cm.value/100f + Long_mm.value/1000f;
		y = Alt_m.value + Alt_cm.value/100f + Alt_mm.value/1000f;
		z = Anc_m.value + Anc_cm.value/100f + Anc_mm.value/1000f;

		this.transform.localScale = new Vector3 (x, y, z);

		LuzSuperior.range = Range.value * 100;
		LuzSuperior.intensity = Intensity.value/50;

	}
}
