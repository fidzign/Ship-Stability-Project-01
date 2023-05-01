using UnityEngine;
using System.Collections;

public class myGUINew : MonoBehaviour {

	public Rect frmContainer = new Rect(20, 20, 580, 83);
	public Rect frmMode = new Rect(690, 20, 280, 83);

	public Rect frmBay = new Rect (20, 109, 330, 225);
	public Rect frmRow = new Rect (390, 109, 210, 65);
	public Rect frmTier = new Rect (408, 109, 190, 150);

	public bool bayWindow0 = false;
	public bool rowWindow0 = false;
	public bool tierWindow0 = false;


	private int[]bay  = {1,3,5,7,9,11,13,15};
	private int[]row  = {1,2,3,4,5};
	private int[]tier = {1,2,3,4,5};

	public float _btnWidth=40;
	public float _btnHight=40;

	

	public GameObject container;
	public GameObject shipMode;
	public Material shader1;
	public Material shader2;
	
	private GameObject clone;


	void start(){
	
		shipMode = GameObject.FindWithTag("lambung");

	
	}

	void OnGUI() {
		//form load container
		frmContainer = GUI.Window(0,frmContainer, formWindow, "Ship Stability");
		frmMode = GUI.Window(1,frmMode, formMode, "Mode/FX");

		if (bayWindow0){
			GUI.Window(2,frmBay , bayWindow, "BAY");
		}
		if (rowWindow0){
			GUI.Window(3,frmRow , rowWindow, "ROW");
		}

	}

	void bayWindow(int windowID) {



				for (int y=0; y<tier.Length; y++) {

						for (int x=0; x<bay.Length; x++) {
								if (bay [x] == 1) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (56.5f, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 3) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (44, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 5) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (23.8f, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 7) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (11.8f, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 9) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (0, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 11) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (-12, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 13) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (-34.8f, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										}
								} else if (bay [x] == 15) {
										if (GUI.Button (new Rect (5 + (x * _btnWidth), 60, _btnWidth, _btnHight), "")) {
							
												gameObject.transform.position = new Vector3 (-47.2f, 40, 7.5f);
												clone = Instantiate (container, transform.position, transform.rotation)as GameObject;
												print (clone);
										}
								} else {
										print ("unload container");
								}
					

						}//else if(GUI.Button(new Rect(5,60+(y*_btnHight),_btnWidth,_btnHight),markT)){
						//loadTierContainer(tier[y]);
						//markT = "[]";
				}

				for (int z=0; z<bay.Length; z++) {
						GUI.Button (new Rect (5 + (z * _btnWidth), 20, _btnWidth, _btnHight), bay [z].ToString ());//untuk nomor bay
				}

				GUI.DragWindow ();

		}

	void rowWindow(int windowID) {
				for (int r=0; r<row.Length; r++) {
						if (row [r] == 1) {
								if (GUI.Button (new Rect (5 + (r * _btnWidth), 20, _btnWidth, _btnHight), "")) {
										gameObject.transform.position = new Vector3 (-47.2f, 40, 7.5f);
										clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										print ("row 1 :" + r);
								}
						} else if (row [r] == 2) {
								if (GUI.Button (new Rect (5 + (r * _btnWidth), 20, _btnWidth, _btnHight), "")) {
										gameObject.transform.position = new Vector3 (-47.2f, 40, 2.5f);
										clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										print ("row 2 :" + r);
								}
						} else if (row [r] == 3) {
								if (GUI.Button (new Rect (5 + (r * _btnWidth), 20, _btnWidth, _btnHight), "")) {
										gameObject.transform.position = new Vector3 (-47.2f, 40, -2.5f);
										clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										print ("row 3 :" + r);
								}
						} else if (row [r] == 4) {
								if (GUI.Button (new Rect (5 + (r * _btnWidth), 20, _btnWidth, _btnHight), "")) {
										gameObject.transform.position = new Vector3 (-47.2f, 40, -7.5f);
										clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										print ("row 4 :" + r);
								}
						} else if (row [r] == 5) {
								if (GUI.Button (new Rect (5 + (r * _btnWidth), 20, _btnWidth, _btnHight), "")) {
										gameObject.transform.position = new Vector3 (-47.2f, 40, -12.5f);
										clone = Instantiate (container, transform.position, transform.rotation) as GameObject;
										print ("row 5 :" + r);
								}
						} else {
								print ("unload container");
						}
							
						//GUI.DragWindow ();
		
				}
		}


	void tierWindow(int windowID) {

		GUI.DragWindow();
		
	}

	
	void formWindow(int windowID) {

		bayWindow0 = GUI.Toggle(new Rect(20, 35, 50, 20), bayWindow0, "BAY");
		rowWindow0 = GUI.Toggle(new Rect(230, 35, 50, 20), rowWindow0, "ROW");

		GUI.DragWindow();
	}

	void modeTransparan(){
		shipMode.transform.gameObject.GetComponent<Renderer>().material = shader2;
	}

	void modeNormal(){
		shipMode.transform.gameObject.GetComponent<Renderer>().material = shader1;
	}



	//---------form mode fx
	void formMode(int windowID) {


		if (GUI.Button (new Rect (10, 25, 50, 50), "SLD")) {
			modeNormal();
			print ("Normal");
		}

		if (GUI.Button (new Rect (80, 25, 50, 50), "TRNS")) {
			modeTransparan();
			print ("Transparan");
		}

		if (GUI.Button (new Rect (150, 25, 50, 50), "ULD")) {
			Destroy(GameObject.FindWithTag("container"));
		}

		if(GUI.Button(new Rect(220, 25, 50, 50), "X")){
			Application.Quit();
		}

		GUI.DragWindow();

	}

	void Update() {

	}
	
}






	
