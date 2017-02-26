using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScreen : MonoBehaviour {

	public void OnPopulationClicked(){
		GameManager.instance.mode = GameManager.GameMode.Timed;
		Application.LoadLevel("StartScreen");
	}

	public void OnBalanceClicked(){
		GameManager.instance.mode = GameManager.GameMode.Equalize;
		Application.LoadLevel("EqualizationStartScreen");
	}
	public void OnAdoptionClicked(){
		GameManager.instance.mode = GameManager.GameMode.Capture;
		Application.LoadLevel("StartScene");
	}
}
