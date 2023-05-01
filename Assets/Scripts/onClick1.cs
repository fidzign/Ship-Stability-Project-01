using UnityEngine;
using System.Collections;

public class onClick1 : MonoBehaviour {

    public GameObject[] chart;



    void Start()
    {

        chart[0].active = true;
        chart[1].active = false;
        chart[2].active = false;
        chart[3].active = false;

    }

    void Disable()
    {
        chart[1].active = false;
        chart[2].active = false;
        chart[3].active = false;
    }

	// Use this for initialization
    void OnClick()
    {

        Disable();
        chart[0].active =! chart[0].active;


    }
}
