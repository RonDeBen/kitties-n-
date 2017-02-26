using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public enum GameMode {Timed, Equalize, Capture};

	public int startKittens, startDoggies, endKittens, endDoggies, level = 0;

	public GameMode mode;

	public static GameManager instance;

	void Awake(){
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
	}

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
		MusicMiddleware.loopSound("catSongEdited",true);
	}

    public void ResetValues()
    {
        startKittens = 0;
        startDoggies = 0;
        endKittens = 0;
        endDoggies = 0;
        level = 0;
    }
}
