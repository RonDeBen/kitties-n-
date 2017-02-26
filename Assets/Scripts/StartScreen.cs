using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

	public InputField kittenIF, doggieIF;
	public Button startButton;
	public int maxValue;
	private string kittenString = "", doggieString = "";
	private int kittenNum, doggieNum;
	private bool validKittenInt = false, validDoggieInt = false;

	// Use this for initialization
	void Start () {
		kittenIF.onValueChange.AddListener (delegate {KittenValueChangeCheck ();});
		doggieIF.onValueChange.AddListener (delegate {DoggieValueChangeCheck ();});
        GameManager.instance.ResetValues();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void KittenValueChangeCheck(){
		bool validInteger = int.TryParse(kittenIF.text, out kittenNum);
		if(validInteger || kittenIF.text == ""){
			kittenString = kittenIF.text;
			if(kittenNum > 0){
				if(kittenNum > maxValue){
					kittenNum = maxValue;
					kittenString = maxValue.ToString();
					kittenIF.text = maxValue.ToString();
				}
				validKittenInt = true;
			}else{
				validKittenInt = false;
			}
		}else{
			kittenIF.text = kittenString;
		}
		CheckIfBothInputsAreValid();
	}

	public void DoggieValueChangeCheck(){
		bool validInteger = int.TryParse(doggieIF.text, out doggieNum);
		if(validInteger || doggieIF.text == ""){
			doggieString = doggieIF.text;
			if(doggieNum > 0){
				if(doggieNum > maxValue){
					doggieNum = maxValue;
					doggieString = maxValue.ToString();
					doggieIF.text = maxValue.ToString();
				}
				validDoggieInt = true;
			}else{
				validDoggieInt = false;
			}
		}else{
			doggieIF.text = doggieString;
		}
		CheckIfBothInputsAreValid();
	}

	public void CheckIfBothInputsAreValid(){
		if(validDoggieInt && validKittenInt){
			startButton.interactable = true;
		}else{
			startButton.interactable = false;
		}
	}

	public void OnStartButtonClicked(){
		GameManager.instance.startDoggies = doggieNum;
		GameManager.instance.startKittens = kittenNum;
		Application.LoadLevel("GameScene2");
	}
}
