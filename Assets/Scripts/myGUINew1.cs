//using UnityEngine;
//using System.Collections;
//
//public class myGUINew1 : MonoBehaviour
//{
//		//---------------GUI--------------------------------------------
//		private Rect frmContainer = new Rect (20, 500, 580, 83);
//		
//		private Rect frmBay = new Rect (20, 109, 330, 225);
//		private Rect frmRow = new Rect (390, 109, 210, 65);
//		private Rect frmTier = new Rect (408, 109, 190, 150);
//		private bool bayWindow0 = false;
//		private bool rowWindow0 = false;
//		private bool tierWindow0 = false;
//		private float _btnWidth = 40;
//		private float _btnHight = 40;
//		//-------------------------------------------------------------------
//
//		private int[]bay = {1,3,5,7,9,11,13,15};
//		private int[]row = {1,2,3,4,5};
//		private int[]tier = {1,2,3,4,5};
//		public GameObject container;
//		public GameObject shipMode;
//		public Transform shipVessel;
//		public Material shader1;
//		public Material shader2;
//		private GameObject clone;//clone container
//		private float berat_kontener;
//		private float berat_kapal ;
//		private float total ;
//		private float rollSlideVal = 0.0f;
//		private float pitchSlideVal = 0.0f;
//		private float draft;
//		private float maxAngle = 30.0f;
//		private float minAngle = -30.0f;
//		
//		public GameObject water;
//
//		void start ()
//		{
//	
//				shipMode = GameObject.FindWithTag ("lambung");
//				
//				
//				berat_kontener = container.rigidbody.mass;
//				berat_kapal = shipVessel.rigidbody.mass;
//
//				
//				//total = berat_kapal + berat_kontener;
//
//	
//		}
//
//		void Update ()
//		{
//
//				PitchRoll ();
//				Draft ();
//				//print ("Draft : " + draft);
//
//		}
//		
//		void PitchRoll ()
//		{
//
//				shipVessel.transform.localEulerAngles = new Vector3 (pitchSlideVal, 0, rollSlideVal);
//
//		}
//
//		void Draft ()
//		{
//
//				draft = shipVessel.transform.localPosition.y*10;
//
//
//		}
//
//		void formWindow (int windowID)
//		{
//		
//////				bayWindow0 = GUI.Toggle (new Rect (20, 25, 50, 20), bayWindow0, "BAY");
//////				rowWindow0 = GUI.Toggle (new Rect (20, 55, 50, 20), rowWindow0, "ROW");
////		
////				GUI.Label (new Rect (100, 25, 50, 20), "Pitch");
////				GUI.Label (new Rect (100, 55, 50, 20), "Roll");
////				GUI.Label (new Rect (400, 25, 50, 20), "Draft");
////		
////				rollSlideVal = GUI.HorizontalSlider (new Rect (150, 30, 100, 30), rollSlideVal, minAngle, maxAngle);
////				pitchSlideVal = GUI.HorizontalSlider (new Rect (150, 60, 100, 30), pitchSlideVal, minAngle, maxAngle);
////		
////				GUI.Box (new Rect (260, 25, 50, 20), rollSlideVal.ToString ("0#.##"));
////				GUI.Box (new Rect (260, 55, 50, 20), pitchSlideVal.ToString ("0#.##"));
////				GUI.Box (new Rect (450, 25, 50, 20), draft.ToString ("##.#"));
////
////				if (GUI.Button (new Rect (400, 55, 100, 20), "Reset")) {
////						resetVal ();
////						print ("reset");
////				}
////		
////				GUI.DragWindow ();
//		}
//	void resetVal(){
//	
//		rollSlideVal = 0.0f;
//		pitchSlideVal = 0.0f;
//		
//	}
//
//		void OnGUI ()
//		{
//				//form load container
//			//	frmContainer = GUI.Window (5, frmContainer, formWindow, "Ship Stability");
////				frmMode = GUI.Window (1, frmMode, formMode, "Mode/FX");
//
////				if (bayWindow0) {
////						GUI.Window (2, frmBay, bayWindow, "BAY");
////				}
////				if (rowWindow0) {
////						GUI.Window (3, frmRow, rowWindow, "ROW");
////				}
//
//		}
//
//		void bayWindow (int windowID)
//		{
//
//				
//		}
//
//		void rowWindow (int windowID)
//		{
//				
//		}
//
//		void tierWindow (int windowID)
//		{
//
//				GUI.DragWindow ();
//		
//		}
//		
//		
//		
//}