using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrawer2 : MonoBehaviour {

    public Transform cube;

    private Vector3 minPoint, maxPoint;
    private ShoeBox cub;

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
            Rect rect = new Rect();
            rect.min = minPoint;
            rect.max = maxPoint;
            
            cub.transform.position = rect.center;
            cub.transform.localScale = rect.size;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cub.DrawEndAction();
        }
    }
}
