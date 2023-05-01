using UnityEngine;
using System.Collections;

public class valLookup : MonoBehaviour {

    public GUIVessel vChart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(120, 750, 200, 25), "KG (m)");
		GUI.Box(new Rect(250, 750, 100, 25), vChart.mmToM(vChart.kgDataOrca3D).ToString("F2"));

        GUI.Label(new Rect(120, 780, 200, 25), "KM Transversal (m)");
		GUI.Box(new Rect(250, 780, 100, 25), vChart.mmToM(vChart.dKMTVal).ToString("F2"));

        GUI.Label(new Rect(120, 810, 200, 25), "KM Longitudinal (m)");
		GUI.Box(new Rect(250, 810, 100, 25), vChart.mmToM(vChart.dKMLVal).ToString("F2"));

        GUI.Label(new Rect(120, 840, 200, 25), "GZ (m)");
		GUI.Box(new Rect(250, 840, 100, 25), vChart.mmToM(vChart.dGZVal).ToString("F2"));

        GUI.Label(new Rect(400, 750, 200, 25), "Draft.T (m)");
		GUI.Box(new Rect(500, 750, 100, 25), vChart.mmToM(vChart.dDraftVal).ToString("F2"));

        GUI.Label(new Rect(400, 780, 200, 25), "KB (m)");
		GUI.Box(new Rect(500, 780, 100, 25), vChart.mmToM(vChart.dKBTVal).ToString("F2"));

        GUI.Label(new Rect(400, 810, 200, 25), "TCB (m)");
		GUI.Box(new Rect(500, 810, 100, 25), vChart.mmToM(vChart.dTCBVal).ToString("F2"));

        GUI.Label(new Rect(400, 840, 200, 25), "LCB (m)");
		GUI.Box(new Rect(500, 840, 100, 25), vChart.mmToM(vChart.dLCBVal).ToString("F2"));

        GUI.Label(new Rect(650, 750, 200, 25), "LCF (m)");
		GUI.Box(new Rect(750, 750, 100, 25), vChart.mmToM(vChart.dLCFVal).ToString("F2"));

        GUI.Label(new Rect(650, 780, 200, 25), "Disp (ton)");
		GUI.Box(new Rect(750, 780, 100, 25), vChart.KgtoTon(vChart.dDispVal).ToString("F2"));

        GUI.Label(new Rect(650, 810, 200, 25), "Container count");
        GUI.Box(new Rect(750, 810, 100, 25), vChart._JumCon.ToString());

        GUI.Label(new Rect(650, 840, 200, 25), "Total load (ton)");
		GUI.Box(new Rect(750, 840, 100, 25), vChart.KgtoTon(vChart._BobotTotal).ToString("F2"));


        GUI.Label(new Rect(860, 750, 200, 25), "CG Lightship");

        GUI.Label(new Rect(860, 780, 200, 25), "x(m)");
		GUI.Box(new Rect(910, 780, 100, 25), vChart.mmToM(vChart.xCGLightShip).ToString("F2"));

        GUI.Label(new Rect(860, 810, 200, 25), "y(m)");
		GUI.Box(new Rect(910, 810, 100, 25), vChart.mmToM(vChart.yCGLightShip).ToString("F2"));

        GUI.Label(new Rect(860, 840, 200, 25), "z(m)");
		GUI.Box(new Rect(910, 840, 100, 25), vChart.mmToM(vChart.zCGLightShip).ToString("F2"));


        GUI.Label(new Rect(1030, 750, 200, 25), "CG Total Load");

        GUI.Label(new Rect(1030, 780, 200, 25), "x(m)");
		GUI.Box(new Rect(1080, 780, 100, 25), vChart.mmToM(vChart.xCGTotalLoad).ToString("F2"));

        GUI.Label(new Rect(1030, 810, 200, 25), "y(m)");
		GUI.Box(new Rect(1080, 810, 100, 25), vChart.mmToM(vChart.Gmx).ToString("F2"));

        GUI.Label(new Rect(1030, 840, 200, 25), "z(m)");
		GUI.Box(new Rect(1080, 840, 100, 25), vChart.mmToM(vChart.Gmy).ToString("F2"));


        GUI.Label(new Rect(1200, 750, 200, 25), "CG Total Ship");

        GUI.Label(new Rect(1200, 780, 200, 25), "x(m)");
		GUI.Box(new Rect(1250, 780, 100, 25), vChart.mmToM(vChart.xCGTotalShip).ToString("F2"));

        GUI.Label(new Rect(1200, 810, 200, 25), "y(m)");
		GUI.Box(new Rect(1250, 810, 100, 25), vChart.mmToM(vChart.yCGTotalShip).ToString("F2"));

        GUI.Label(new Rect(1200, 840, 200, 25), "z(m)");
		GUI.Box(new Rect(1250, 840, 100, 25), vChart.mmToM(vChart.zCGTotalShip).ToString("F2"));



        float _vTrim = -vChart.dTrimVal;
        float _vList = -vChart.dHeelVal;

        string infoList;
        string infoTrim;





        if (_vTrim > 0)
        {
            infoTrim = "By Stern";

        }
        else if (_vTrim == 0)
        {
            infoTrim = "-";
        }
        else
        {
            infoTrim = "By Bow";
        }

       GUI.Label(new Rect(1380, 750, 100, 25), "Trim (deg)");
       GUI.Box(new Rect(1380, 775, 60, 25), _vTrim.ToString("F2"));
       GUI.Box(new Rect(1460, 775, 80, 25), infoTrim);

       if (_vList > 0)
       {
           infoList = "P";

       }
       else if (_vList == 0)
       {
           infoList = "-";
       }
       else
       {
           infoList = "S";
       }

       GUI.Label(new Rect(1380, 815, 100, 25), "List (deg)");
       GUI.Box(new Rect(1380, 840, 60, 25), Mathf.Abs(_vList).ToString("F2"));

       //GUI.Label(new Rect(1380, 815, 50, 25), "List (deg)");
       GUI.Box(new Rect(1460, 840, 80, 25), infoList);
    }

}
