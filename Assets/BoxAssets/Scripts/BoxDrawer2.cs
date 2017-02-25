using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrawer2 : MonoBehaviour {

    public static BoxDrawer2 singleton;

    public Transform cube;

    public Rect rect;

    private Vector3 minPoint, maxPoint;
    private ShoeBox cub;

    void Awake()
    {
        singleton = this;
        rect = new Rect();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
    }
}
