using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPopulaiton : MonoBehaviour {

	public Text thing;
	public int goalKittens;

	// Use this for initialization
	void Start () {
		WriteEnding();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WriteEnding(){
		if(GameManager.instance.mode == GameManager.GameMode.Timed){
			thing.text = "You ended with " + GameManager.instance.endKittens + " kittens. " + Mathf.Abs(goalKittens - GameManager.instance.endKittens) + " away from your goal of " + goalKittens;
		}else if(GameManager.instance.mode == GameManager.GameMode.Equalize){
			thing.text = "Congratulations! You regulated the populations in " + GameManager.instance.gameTime.ToString("F1") + " seconds." + "\n" +
			"In the process you adoped " + GameManager.instance.adoptedKittens + " kittens and " + GameManager.instance.adoptedDoggies + 
			" puppies, and you released " + GameManager.instance.releasedDoggies + " puppies.";


		}
	}

	public void OnNewGameClicked(){
		Application.LoadLevel("StartScreen");
	}

	public void OnBackToStartClicked(){
		Application.LoadLevel("SelectionScreen");
	}
}
