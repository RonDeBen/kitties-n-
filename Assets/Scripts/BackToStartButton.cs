using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStartButton : MonoBehaviour {

	public void OnBackToStartClicked(){
		Application.LoadLevel("SelectionScreen");
	}
}
