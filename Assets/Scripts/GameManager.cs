using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int startKittens, startDoggies, endKittens, endDoggies;

	public static GameManager instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
}
