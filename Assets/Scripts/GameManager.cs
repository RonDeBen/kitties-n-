using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public enum GameMode {Timed, Equalize, Capture};

	public int startKittens, startDoggies, endKittens, endDoggies, level = 0;

	public GameMode mode;

	public static GameManager instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		MusicMiddleware.loopSound("catSongEdited",true);
	}
}
