using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class GUITest : MonoBehaviour {

    // VARIABLE DECLARATION POINTVALUES
    public List<Vector2> pointSeries1;
    public List<Vector2> pointSeries2;

	// Use this for initialization
	void Start () {

        // SETTINGS POIN VALUES
        pointSeries1.Add(new Vector2(0.0f, 10f));
        pointSeries1.Add(new Vector2(0.0f, 9f));
        pointSeries1.Add(new Vector2(0.0f, 8f));
        pointSeries1.Add(new Vector2(0.0f, 7f));
        pointSeries1.Add(new Vector2(0.0f, 6f));
        pointSeries1.Add(new Vector2(0.0f, 5f));
        pointSeries1.Add(new Vector2(0.0f, 6f));
        pointSeries1.Add(new Vector2(0.0f, 7f));
        pointSeries1.Add(new Vector2(0.0f, 8f));
        pointSeries1.Add(new Vector2(0.0f, 9f));
        pointSeries1.Add(new Vector2(0.0f, 10f));

        pointSeries2.Add(new Vector2(0.0f, 5f));
        pointSeries2.Add(new Vector2(0.0f, 6f));
        pointSeries2.Add(new Vector2(0.0f, 7f));
        pointSeries2.Add(new Vector2(0.0f, 8f));
        pointSeries2.Add(new Vector2(0.0f, 9f));
        pointSeries2.Add(new Vector2(0.0f, 10f));
        pointSeries2.Add(new Vector2(0.0f, 9f));
        pointSeries2.Add(new Vector2(0.0f, 8f));
        pointSeries2.Add(new Vector2(0.0f, 7f));
        pointSeries2.Add(new Vector2(0.0f, 6f));
        pointSeries2.Add(new Vector2(0.0f, 5f));
	}

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 500, 300), "Loader Menu");

        if (GUI.Button(new Rect(20, 40, 80, 20), "Draw Chart"))
        {
            // SEND DATA TO WMG SERIES (Series1 and Series2 is name of GameObject Chart Series)
            GameObject.Find("Series1").GetComponent("WMG_Series").SendMessage("setPointValues", pointSeries1);
            GameObject.Find("Series1").GetComponent("WMG_Series").SendMessage("setPointValuesChanged", true);
            GameObject.Find("Series2").GetComponent("WMG_Series").SendMessage("setPointValues", pointSeries2);
            GameObject.Find("Series2").GetComponent("WMG_Series").SendMessage("setPointValuesChanged", true);
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "Draw Chart"))
        {
            // SEND DATA TO WMG SERIES (Series1 and Series2 is name of GameObject Chart Series)
            GameObject.Find("Series1").GetComponent("WMG_Series").SendMessage("setPointValues", pointSeries2);
            GameObject.Find("Series1").GetComponent("WMG_Series").SendMessage("setPointValuesChanged", true);
            GameObject.Find("Series2").GetComponent("WMG_Series").SendMessage("setPointValues", pointSeries1);
            GameObject.Find("Series2").GetComponent("WMG_Series").SendMessage("setPointValuesChanged", true);
        }
    }

	// Update is called once per frame
	void Update () {
        
	}
}
