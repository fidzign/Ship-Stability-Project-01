using UnityEngine;
using System.Collections;

public class loadShip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnGUI()
    {
        if (GUI.Button(new Rect(25, 600, 100, 30), "Tanker"))
        {
            Application.LoadLevel("SC_TANKER6300");
        }
        if(GUI.Button(new Rect(130, 600, 100, 30), "Container"))
        {
            Application.LoadLevel("SC_CONTAINER4180");
           
        }
        if (GUI.Button(new Rect(235, 600, 100, 30), "Bulk Carrier"))
        {
            Application.LoadLevel("SC_BULKCARIER");

        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
