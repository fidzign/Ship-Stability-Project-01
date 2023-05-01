using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EShipLoad : MonoBehaviour {

	public GameObject[] Beban;
	public InputField[] iBeban;

	private float B1,B2,B3,B4,mBeban;



	// Use this for initialization
	void Start () {

		ResetBeban();

    }

	public void InputBeban()
    {

		foreach (GameObject bObject in Beban)
		{
			if (bObject.AddComponent<Rigidbody>() == null)
			{
				bObject.AddComponent<Rigidbody>();
			}
		}

		B1 = float.Parse(iBeban[0].text);
		B2 = float.Parse(iBeban[1].text);
		B3 = float.Parse(iBeban[2].text);
		B4 = float.Parse(iBeban[3].text);

		float tBeban = B1 + B2 + B3 + B4;

		if (B1 > 500f || B2 > 500f || B3 > 500f || B4 > 500f)
		{
			Debug.Log("Masukan Nilai dari 1-500");
			B1 = 1;
			B2 = 1;
			B3 = 1;
			B4 = 1;
			ResetBeban();
		}
		

		Beban[0].GetComponent<Rigidbody>().mass = B1;
		Beban[0].transform.localScale = new Vector3(0.5f, B1/1000, 0.5f);

		Beban[1].GetComponent<Rigidbody>().mass = B2;
		Beban[1].transform.localScale = new Vector3(0.5f, B2 / 1000, 0.5f);

		Beban[2].GetComponent<Rigidbody>().mass = B3;
		Beban[2].transform.localScale = new Vector3(0.5f, B3 / 1000, 0.5f);

		Beban[3].GetComponent<Rigidbody>().mass = B4;
		Beban[3].transform.localScale = new Vector3(0.5f, B4 / 1000, 0.5f);


		Debug.Log("Total Beban = " + tBeban);

	}

	public void ResetBeban()
    {
		
        foreach (GameObject bObject in Beban)
        {
			mBeban = 0;
			bObject.GetComponent<Rigidbody>().mass = mBeban;
			bObject.transform.localScale = new Vector3(0.5f, 0f, 0.5f);
			Destroy(bObject.GetComponent<Rigidbody>());
		}
        
		foreach(InputField ibeban in iBeban)
        {
			ibeban.text = mBeban.ToString();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
