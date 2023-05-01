using UnityEngine;
using System.Collections;

public class onClick6 : MonoBehaviour {

    public GameObject[] chart;
    


    void Start()
    {

        chart[0].active = true;
        chart[1].active = false;
      
   

    }

    void Disable()
    {
        chart[1].active = false;
       
     
    }

	// Use this for initialization
    void OnClick()
    {

        Disable();
        chart[0].active = true;


    }
}
