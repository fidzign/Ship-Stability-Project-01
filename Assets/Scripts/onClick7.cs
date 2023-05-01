using UnityEngine;
using System.Collections;

public class onClick7 : MonoBehaviour {

    public GameObject[] chart;
   


    void Start()
    {

        chart[0].active = false ;
        chart[1].active = true;
      
   

    }

    void Disable()
    {
        chart[0].active = false;
       
     
    }

	// Use this for initialization
    void OnClick()
    {

        Disable();


        chart[1].active = true;


    }
}
