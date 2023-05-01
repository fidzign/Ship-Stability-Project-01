using UnityEngine;
using System.Collections;

public class MonitoringInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(400, 500, 400, 500));
        GUILayout.Label("Draft");
        GUILayout.EndArea();


    }
}
