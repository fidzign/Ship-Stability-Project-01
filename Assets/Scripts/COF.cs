using UnityEngine;
using System.Collections;

public class COF : MonoBehaviour {

    private float sldCF, sldRot, sldRot2;
    private float minAngleT = -2f, maxAngleT = 2f;

    private float minT = 0f, maxT = 5f;

    public GameObject Ship;
    public GameObject pivot;

    private bool _mouseState;
    public GameObject Target;
    public Vector3 screenSpace;
    public Vector3 offset;

    public Vector3 screenSpace2;
    public Vector3 offset2;

    public Camera cam1,cam2;



	// Use this for initialization
	void Start () {

        sldCF = 0f;
        sldRot = 2.5f;
        sldRot2 = 2.5f;

        
	}
    void OnGUI()
    {
      
        GUI.Label(new Rect(20, 100, 100, 30), "Pitch");
        sldRot = GUI.HorizontalSlider(new Rect(50, 105, 100, 30), sldRot, minT, maxT);
        GUI.Label(new Rect(200, 100, 100, 30), "" + Pos(sldRot).ToString("#0.0"));

        GUI.Label(new Rect(20, 150, 100, 30), "Roll");
        sldRot2 = GUI.HorizontalSlider(new Rect(50, 155, 100, 30), sldRot2, minT, maxT);
        GUI.Label(new Rect(200, 150, 100, 30), "" + Pos(sldRot2).ToString("#0.0"));

        if (GUI.Button(new Rect(20, 200, 200, 30), "Reset Val"))
        {
            Ship.transform.position = new Vector3(0, 0, 0);
            Ship.transform.eulerAngles = new Vector3(0, 0, 0);
            sldCF = 0f;
            sldRot = 2.5f;
            sldRot2 = 2.5f;
        }

        
    }
	// Update is called once per frame

    void DragDrop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Target == GetClickedObject(out hitInfo))
            {
                _mouseState = true;
                Ship.transform.parent = null;
                //screenSpace = Camera.main.WorldToScreenPoint(Target.transform.position);
                screenSpace = cam1.WorldToScreenPoint(Target.transform.position);
                screenSpace2 = cam2.WorldToScreenPoint(Target.transform.position);
                
               // offset = Target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

                offset = Target.transform.position - cam1.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                offset2 = Target.transform.position - cam2.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace2.z));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseState = false;
            Ship.transform.parent = pivot.transform;
        }
        if (_mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            var curScreenSpace2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace2.z);

            //convert the screen mouse position to world point and adjust with offset
            //var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            var curPosition = cam1.ScreenToWorldPoint(curScreenSpace) + offset;
            var curPosition2 = cam2.ScreenToWorldPoint(curScreenSpace2) + offset2;

            //update the position of the object in the world
            Target.transform.position = curPosition;
            Target.transform.position = curPosition2;
        }
    }
	void Update () {

        DragDrop();

        if (sldRot != null || sldRot2 != null)
        {
            pivot.transform.eulerAngles = new Vector3(Pos(sldRot2), 0, Pos(sldRot));

        }

	}
    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    private float Pos(float v_in)
    {
        float v_min, v_max, pos_min, pos_max, posisi;

        v_min = 0;
        v_max = 5;

        pos_min = -30;
        pos_max = 30;

        posisi = ((pos_max - pos_min) / (v_max - v_min)) * (v_in - v_min) + pos_min;

        return posisi;
    }//konversi sudut

}
