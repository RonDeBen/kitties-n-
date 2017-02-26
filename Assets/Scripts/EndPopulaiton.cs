using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPopulaiton : MonoBehaviour {

	public Text thing;
	public int goalKittens;

	// Use this for initialization
	void Start () {
		int endKittens = GameManager.instance.endKittens;
		thing.text = "You ended with " + endKittens.ToString() + " kittens. " + Mathf.Abs(goalKittens - endKittens).ToString() + " away from your goal of " + goalKittens.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnNewGameClicked(){
		Application.LoadLevel("StartScreen");
	}
}
