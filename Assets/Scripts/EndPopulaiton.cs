using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPopulaiton : MonoBehaviour {

	public Text thing;
	public int goalKittens;
	public Button RestartButton;

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

			int nextLevel = GameManager.instance.level + 1;
			if(nextLevel > 4){
				RestartButton.enabled = false;
				RestartButton.GetComponentInChildren<Text>().text = "You Win!";
			}else{
				RestartButton.GetComponentInChildren<Text>().text = "Level " + (nextLevel+1) + "?";
			}
        }
        else if(GameManager.instance.mode == GameManager.GameMode.Capture)
        {
            thing.text = "You adopted "+GameManager.instance.adoptedKittens+" kittens!\n"+
                "You also adopted "+GameManager.instance.adoptedDoggies+" puppies.\n"+
                "High score is "+PlayerPrefs.GetInt("CaptureHighScore")+ " kittens";
        }
	}

	public void OnNewGameClicked(){
		if(GameManager.instance.mode == GameManager.GameMode.Timed){
			Application.LoadLevel("StartScreen");
		}else if(GameManager.instance.mode == GameManager.GameMode.Equalize){
			GameManager.instance.level++;
			Application.LoadLevel("EqualizationStartScreen");
		}else if(GameManager.instance.mode == GameManager.GameMode.Capture)
        {
            Application.LoadLevel("GameScene2");
        }
	}

}
