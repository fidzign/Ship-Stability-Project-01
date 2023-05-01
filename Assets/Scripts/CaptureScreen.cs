using UnityEngine;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System;

public class CaptureScreen : MonoBehaviour {


    public GameObject[] label;

    private bool setActive = false;
    public Camera Cam;
    public Color32 color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
	// Use this for initialization
	void Start () {

       // Cam = GetComponent<Camera>();
        Cam.clearFlags = CameraClearFlags.SolidColor;
	
	}

    void notActive()
    {

        label[0].SetActive(false);
        label[1].SetActive(false);
        label[2].SetActive(false);
        label[3].SetActive(false);
        label[4].SetActive(false);
        label[5].SetActive(false);
        label[6].SetActive(false);
        label[7].SetActive(true);

    }

    void tActive()
    {

        label[0].SetActive(true);
        label[1].SetActive(true);
        label[2].SetActive(true);
        label[3].SetActive(true);
        label[4].SetActive(true);
        label[5].SetActive(true);
        label[6].SetActive(true);
        label[7].SetActive(false);

    }

    
    void OnClick()
    {

        notActive();
          

            Application.CaptureScreenshot(Application.dataPath + "/../graph.png", 1);
            System.Diagnostics.Process.Start(Application.dataPath + "/../graph.png");
          
        
    }

    void OnMouseDown()
    {
        tActive();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tActive();

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            notActive();
            Cam.backgroundColor = Color.Lerp(color, color,1);



            Application.CaptureScreenshot(Application.dataPath + "/../graph.png", 2);
            System.Diagnostics.Process.Start(Application.dataPath + "/../graph.png");

        }


       
       
	
	}
}
