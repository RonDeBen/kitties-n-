using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour {

	public static GameBounds instance;
	public float width, height;

	void Awake(){
		instance = this;

	    height = 2f * Camera.main.orthographicSize;
	    width = height * Camera.main.aspect;

	    Vector3 newPosition = new Vector3(transform.position.x - width / 2, transform.position.y - height / 2, 0);
	    
	    float offsetX = transform.position.x  - newPosition.x;
	    float offsetY = transform.position.y - newPosition.y;
	    transform.position = new Vector3(offsetX, offsetY, -10);
	}

	// Use this for initialization
	void Start () {
	}
}
