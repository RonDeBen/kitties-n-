using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior for pets. Right now, a convenience behaviour that adds random movement and boxcollider 2d to our pets
/// </summary>
[RequireComponent (typeof(RandomMovement))]
[RequireComponent (typeof(BoxCollider2D))]
public class Pet : MonoBehaviour {

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
