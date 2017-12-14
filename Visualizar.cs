using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class Visualizar : MonoBehaviour {

	private GameObject VRPlayer;
	private GameObject Player;
	private GameObject Cameras;

	private GameObject GI;

	private Button visualiza;
	public Sprite visSprite;
	public Sprite editSprite;

	public Button btn_Gear;

	public bool visactive;

	public void cambioCamara(){

		if (!visactive && VRDevice.isPresent) {

			visualiza.GetComponent<Image> ().sprite = editSprite;

			VRPlayer.SetActive (true);
			Player.SetActive (false);
			VRSettings.enabled = true;

			GI.SetActive (false);

			btn_Gear.transform.localScale = new Vector3 (0, 0, 0);

			Cameras.SetActive (false);

			visactive = true;

		} else if (visactive && VRDevice.isPresent) {

			visualiza.GetComponent<Image> ().sprite = visSprite;

			VRPlayer.SetActive (false);
			Player.SetActive (false);
			VRSettings.enabled = false;

			GI.SetActive (true);

			btn_Gear.transform.localScale = new Vector3 (1, 1, 1);

			Cameras.SetActive (true);

			visactive = false;

		} else if (!visactive && !VRDevice.isPresent) {

			visactive = true;

			visualiza.GetComponent<Image> ().sprite = editSprite;

			Player.SetActive (true);
			VRPlayer.SetActive (false);

			GI.SetActive (false);

			btn_Gear.transform.localScale = new Vector3 (0, 0, 0);

			Cameras.SetActive (false);

		}

		else if (visactive && !VRDevice.isPresent) {

			visactive = false;

			visualiza.GetComponent<Image> ().sprite = visSprite;

			Player.SetActive (false);
			VRPlayer.SetActive (false);

			GI.SetActive (true);

			btn_Gear.transform.localScale = new Vector3 (1, 1, 1);

			Cameras.SetActive (true);

		}
			
	}

	// Use this for initialization
	void Start () {

		Player = GameObject.Find ("Player");
		VRPlayer = GameObject.Find ("OVRPlayerController");
		Cameras = GameObject.Find ("Map_Cameras");
		GI = GameObject.Find ("Room_Dim_Interface");

		visactive = false;

		VRPlayer.SetActive (false);
		Player.SetActive (false);
		VRSettings.enabled = false;

		visualiza = GameObject.Find ("Btn_Visualizar").GetComponent<Button> ();

		visualiza.onClick.AddListener (cambioCamara);

	}

	void Update(){

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		if (visactive) {

			if (VRDevice.isPresent) {
				
				VRSettings.enabled = true;

				VRPlayer.SetActive (true);
				Player.SetActive (false);
			}

			if (!VRDevice.isPresent) {

				VRSettings.enabled = false;

				VRPlayer.SetActive (false);
				Player.SetActive (true);

			}

		}



		if (Input.GetKeyDown (KeyCode.V) || (Input.GetKeyDown(KeyCode.Escape) && visactive)) {

			if (!visactive && VRDevice.isPresent) {

				visualiza.GetComponent<Image> ().sprite = editSprite;

				VRPlayer.SetActive (true);
				VRSettings.enabled = true;

				GI.SetActive (false);

				Cameras.SetActive (false);

				btn_Gear.transform.localScale = new Vector3 (0, 0, 0);

				visactive = true;

			} else if (visactive && VRDevice.isPresent) {

				visualiza.GetComponent<Image> ().sprite = visSprite;

				VRPlayer.SetActive (false);
				VRSettings.enabled = false;

				GI.SetActive (true);

				Cameras.SetActive (true);

				btn_Gear.transform.localScale = new Vector3 (1, 1, 1);

				visactive = false;

			} else if (!visactive && !VRDevice.isPresent) {

				visactive = true;

				visualiza.GetComponent<Image> ().sprite = editSprite;

				Player.SetActive (true);

				GI.SetActive (false);

				btn_Gear.transform.localScale = new Vector3 (0, 0, 0);

				Cameras.SetActive (false);

			}

			else if (visactive && !VRDevice.isPresent) {

				visactive = false;

				visualiza.GetComponent<Image> ().sprite = visSprite;

				Player.SetActive (false);

				GI.SetActive (true);

				btn_Gear.transform.localScale = new Vector3 (1, 1, 1);

				Cameras.SetActive (true);

			}

		}
			
	}

}
