using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EqualizationStartScreen : MonoBehaviour {

	public struct Level{
		public int startingKittens, startingDoggies, goalKittens, goalDoggies, maxKittens, maxDoggies;

		public Level(int startingKittens, int startingDoggies, int goalKittens, 
					int goalDoggies, int maxKittens, int maxDoggies){
			this.startingKittens = startingKittens;
			this.startingDoggies = startingDoggies;
			this.goalKittens = goalKittens;
			this.goalDoggies = goalDoggies;
			this.maxKittens = maxKittens;
			this.maxDoggies = maxDoggies;
		}
	}

	public Text playerPrompt;

	private List<Level> levels = new List<Level>(new Level[]{
		new Level(5, 5, 10, 10, 20, 20),
		new Level(10, 10, 20, 20, 30,30),
		new Level(20, 20, 30, 30, 40, 40),
		new Level(30, 30, 40, 40, 50, 50),
		new Level(40, 40, 50, 50, 100, 100)
		});

	// Use this for initialization
	void Start () {
		Level thisLevel = levels[GameManager.instance.level];
		playerPrompt.text = "In this level you will need to get " + thisLevel.goalKittens + 
		" kittens and " + thisLevel.goalDoggies + " puppies. " + "\n" + 
		"You will start off with " + thisLevel.startingKittens + " kittens and " + thisLevel.startingDoggies + 
		" puppies who are capped at " + thisLevel.maxKittens + " and " + thisLevel.maxKittens + " respectively.";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnStartButtonClicked(){
		Level thisLevel = levels[GameManager.instance.level];
		GameManager.instance.mode = GameManager.GameMode.Equalize;
		GameManager.instance.startDoggies = thisLevel.startingDoggies;
		GameManager.instance.startKittens = thisLevel.startingKittens;
		GameManager.instance.goalDoggies = thisLevel.goalDoggies;
		GameManager.instance.goalKittens = thisLevel.goalKittens;
		GameManager.instance.maxDoggies = thisLevel.maxDoggies;
		GameManager.instance.maxKittens = thisLevel.maxKittens;
		Application.LoadLevel("GameScene2");
	}


}
