﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour {

	public GameObject FPSCamera;

	public float horizontalSpeed;
	public float verticalSpeed;

	float h;
	float v;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		h = horizontalSpeed * Input.GetAxis ("Mouse X");
		v = verticalSpeed * Input.GetAxis ("Mouse Y");

		transform.Rotate (0, h, 0);
		FPSCamera.transform.Rotate (-v, 0, 0);

		if (Input.GetKey (KeyCode.W)) {

			transform.Translate (0, 0, 3.0f);

		} else 
			if (Input.GetKey (KeyCode.S)) {

				transform.Translate (0, 0, -3.0f);

			} else 
				if (Input.GetKey (KeyCode.A)) {

					transform.Translate (-3.0f, 0, 0);
								
				} else 
					if (Input.GetKey (KeyCode.D)) {

						transform.Translate (3.0f, 0, 0);

					
					}
			

	}
}