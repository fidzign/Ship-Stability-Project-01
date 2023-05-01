using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
	public float vSliderValue = 5.0F;//roll
	public float hSliderValue = 5.0F;//pitch

	public Rect frmContainer = new Rect(20, 20, 500, 83);
	public Rect frmMode = new Rect(690, 20, 280, 83);
	public Rect frmLoad = new Rect (20, 150, 190, 150);
	public bool doWindow0 = false;

	public string  bay ; //= {"1","3","5","7","9","10","11","13","15"};
	public string  row  ;//= {"1","2","3","4","5"};
	public string  tear ;//= {"1","2","3","4","5"};

	public bool statKosong = false;
	public bool statIsi    = false;



	void OnGUI() {
		//form load container
		frmContainer = GUI.Window(0,frmContainer, formWindow, "Ship Stability");

		frmMode = GUI.Window(1,frmMode, formMode, "Mode/FX");

		if (doWindow0){
			GUI.Window(2,frmLoad , DoWindow0, "Form Container");
		}

	}

	void DoWindow0(int windowID) {

		GUI.Label (new Rect (10, 30, 100, 20), "Row");
		GUI.Label (new Rect (10, 50, 100, 20), "Bay");
		GUI.Label (new Rect (10, 70, 100, 20), "Tear");

		bay = GUI.TextField(new Rect(80, 30, 100, 20),bay, 25);
		row = GUI.TextField(new Rect(80, 50, 100, 20), row, 25);
		tear = GUI.TextField(new Rect(80, 70, 100, 20),tear, 25);

		int tempBay=System.Convert.ToInt32(bay);
		int tempRow=System.Convert.ToInt32(row);
		int tempTear=System.Convert.ToInt32(tear);



		int hasil = tempBay + tempRow + tempTear;
		if (GUI.Button (new Rect (10, 100, 80, 20), "Load")) {
			if(hasil==10){
				Application.Quit();
				print ("keluar");
			}
		}

		if (GUI.Button (new Rect (100, 100, 80, 20), "Unload")) {
			print ("unloading");
		}


		GUI.DragWindow();

	}



	void formWindow(int windowID) {

		doWindow0 = GUI.Toggle(new Rect(20, 35, 200, 20), doWindow0, "Load Container");
		GUI.DragWindow();
	}

	void formMode(int windowID) {
		
		//tombol load container
		GUI.Button(new Rect(10, 25, 50, 50), "");
		if (GUI.Button (new Rect (80, 25, 50, 50), "")) {
			print ("selected");
		
		}
		GUI.Button(new Rect(150, 25, 50, 50), "");

		if(GUI.Button(new Rect(220, 25, 50, 50), "X")){
			Application.Quit();
		}

		GUI.DragWindow();

	}
	
}






	
