using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrawer2 : MonoBehaviour {
    public static BoxDrawer2 singleton;

    public Transform cube, pupCube;

    public Rect rect, pupRect;

    private Vector3 minPoint, maxPoint;
    private ShoeBox cub;
    private PupBox pupCub;

    void Awake()
    {
        singleton = this;
        rect = new Rect();
        pupRect = new Rect();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Draw pet boxes
        if (Input.GetMouseButtonDown(0))
        {
            minPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cub = Instantiate(cube).GetComponent<ShoeBox>();
        }
        if (Input.GetMouseButton(0))
        {
            maxPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            rect.min = minPoint;
            rect.max = maxPoint;
            
            cub.transform.position = rect.center;
            cub.transform.localScale = rect.size;
            cub.myRect = rect;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cub.DrawEndAction();
        }

        //Draw pup boxes
        if (Input.GetMouseButtonDown(1))//initial right mouse button down
        {
            minPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pupCub = Instantiate(pupCube).GetComponent<PupBox>();
        }
        if (Input.GetMouseButton(1))//moving right mouse button
        {
            maxPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            pupRect.min = minPoint;
            pupRect.max = maxPoint;
            
            pupCub.transform.position = pupRect.center;
            pupCub.transform.localScale = pupRect.size;
            pupCub.myRect = pupRect;
        }
        if (Input.GetMouseButtonUp(1))//release right mouse button
        {
            //pupCub.DrawEndAction();
        }
    }
}
