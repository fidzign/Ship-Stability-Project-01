using UnityEngine;
using System.Collections;

public class colliderW : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "COLL_WATER")
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
            Application.LoadLevel("SC_CONTAINER4180");
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
