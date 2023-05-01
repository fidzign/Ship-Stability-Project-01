using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "container")
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
