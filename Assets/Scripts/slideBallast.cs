using UnityEngine;
using System.Collections;

public class slideBallast : MonoBehaviour {

    private float sldBallast_depan = 0f;
	// Use this for initialization
 
	void Start () {


	
	}
    void OnGUI(){

        sldBallast_depan = GUI.HorizontalSlider(new Rect(50, 100, 100, 30), sldBallast_depan, 0, 1);
        transform.localScale = new Vector3(1, sldBallast_depan, 1);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
