using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
public class ExitMenu : MonoBehaviour {

	private Visualizar VisualizarScript;

	private GameObject visIntf; 

	public Button btn_gear;
	public Button btn_exit;
	public Button btn_volver;
	public Button btn_volverMMenu;

	public int mng_pause;
	public GameObject pnl_exit;
	//public GameObject Room;
	public Camera orbit_camera;
 	public Mouse_Orbit camera_script;
	public RuntimeGizmos.TransformGizmo transformgizmo;
	public GameObject general_interface;

	public void volverMMenu(){

		SceneManager.LoadScene ("MainMenu");

	}

	public void pause(){

		if (!VisualizarScript.visactive) {

			if (mng_pause == -1) {

				mng_pause = 0;
				pnl_exit.SetActive (true);
				//Room.SetActive (false);

				//SCRIPTS DESACTIVADOS
				camera_script.enabled = false;
				transformgizmo.enabled = false;
				visIntf.SetActive (false);

				//INTERFAZ DE INVENTARIO Y TAMAÑO DE OBJETO SELECCIONADO DESACTIVADA
				general_interface.SetActive (false);


			} else if (mng_pause == 0) {

				mng_pause = -1;
				pnl_exit.SetActive (false);
				//Room.SetActive (true);
				camera_script.enabled = true;
				transformgizmo.enabled = true;
				visIntf.SetActive (true);
			
				general_interface.SetActive (true);

			

			}
		}

	}

	public void exit(){

		Application.Quit ();

	}


	// Use this for initialization
	void Start () {

		VisualizarScript = GameObject.Find ("Master_Controller").GetComponent<Visualizar> ();

		mng_pause = -1;

		visIntf = GameObject.Find ("Intf_Visualizar");

		general_interface.SetActive (true);

		//Room.SetActive (true);

		pnl_exit.SetActive (false);

		camera_script = orbit_camera.GetComponent<Mouse_Orbit>();
		transformgizmo = orbit_camera.GetComponent<RuntimeGizmos.TransformGizmo> ();



		Button btnpause = btn_gear.GetComponent<Button>();
		btnpause.onClick.AddListener(pause);

		Button btnexit = btn_exit.GetComponent<Button> ();
		btnexit.onClick.AddListener(exit);

		Button btnvolver = btn_volver.GetComponent<Button> ();
		btnvolver.onClick.AddListener (pause);


		btn_volverMMenu.onClick.AddListener (volverMMenu);

	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Escape) && !VisualizarScript.visactive) {

			if (mng_pause == -1) {

				mng_pause = 0;
				pnl_exit.SetActive (true);
				//Room.SetActive (false);

				//SCRIPTS DESACTIVADOS
				camera_script.enabled = false;
				transformgizmo.enabled = false;



				//INTERFAZ DE INVENTARIO Y TAMAÑO DE OBJETO SELECCIONADO DESACTIVADA
				general_interface.SetActive (false);
				visIntf.SetActive (false);

			} else if (mng_pause == 0) {

				mng_pause = -1;
				pnl_exit.SetActive (false);
				//Room.SetActive (true);
				camera_script.enabled = true;
				transformgizmo.enabled = true;
				general_interface.SetActive (true);
			
				visIntf.SetActive (true);
			}

		}

	}

}
