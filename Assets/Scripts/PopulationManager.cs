using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopulationManager : MonoBehaviour {

	public static PopulationManager instance;

	void Awake(){
		instance = this;
	}

	public GameObject kittenObject, doggieObject;
	public Text kittenText, doggieText, timeText;
	public float a, b, c, d, generationTime, endTime;
	public int maxDoggies, maxKittens, hackStartDog, hackStartCat;

	private List<GameObject> kittenList, doggieList;

	private float catsToSpawn, dogsToSpawn, dogsSpawned, catsSpawned, generationStartTime, gameStartTime;

	private float nextSpawn;
	private int kittenPopulation, doggiePopulation;

	// Use this for initialization
	void Start () {
		kittenList = new List<GameObject>();
		doggieList = new List<GameObject>();
		// SpawnKittens(hackStartCat);
		// SpawnDoggies(hackStartDog);
		SpawnKittens(GameManager.instance.startKittens);
		SpawnDoggies(GameManager.instance.startDoggies);
		nextSpawn = Time.timeSinceLevelLoad;

	}
	
	// Update is called once per frame
	void Update(){
		// LerpAnimals();
		if(Time.timeSinceLevelLoad > endTime){
			EndGame();
		}
		if(doggiePopulation < 1){
			SpawnDoggies(1);
		}
		if(kittenPopulation < 1){
			SpawnKittens(1);
		}
	}

	void FixedUpdate(){
		if(Time.timeSinceLevelLoad > nextSpawn){
			nextSpawn = Time.timeSinceLevelLoad + generationTime;
			GetNextGeneration();
		}
		LerpAnimals();
	}

	public void EndGame(){
		GameManager.instance.endKittens = kittenPopulation;
		GameManager.instance.endDoggies = doggiePopulation;
		Application.LoadLevel("TimeScreen");
	}

	public void LerpAnimals(){
		float percentage = (Time.timeSinceLevelLoad - generationStartTime)/generationTime;
		if(catsToSpawn > 0){//positive change
			float kittenSpawnThisCycle = Mathf.Lerp(0f, catsToSpawn, percentage) - catsSpawned;
			catsSpawned += (int)kittenSpawnThisCycle;
			SpawnKittens((int)kittenSpawnThisCycle);
		}else{//negative change
			float kittenRemoveThisCycle = -(Mathf.Lerp(0f, catsToSpawn, percentage) + catsSpawned);
			catsSpawned += (int)kittenRemoveThisCycle;//should really be catsRemoved
			RemoveKittens((int)kittenRemoveThisCycle);
		}

		if(dogsToSpawn > 0){//positive change
			float doggiesSpawnThisCycle = Mathf.Lerp(0f, dogsToSpawn, percentage) - dogsSpawned;
			dogsSpawned += (int)doggiesSpawnThisCycle;
			SpawnDoggies((int)doggiesSpawnThisCycle);
		}else{//negative change
			float doggiesRemoveThisCycle = -(Mathf.Lerp(0f, dogsToSpawn, percentage) + dogsSpawned);
			dogsSpawned += (int)doggiesRemoveThisCycle;//should really be dogsRemoved
			RemoveDoggies((int)doggiesRemoveThisCycle);
		}

		kittenText.text = "Number of Kittens: " + kittenPopulation.ToString();
		doggieText.text = "Number of Puppies: " + doggiePopulation.ToString();
		timeText.text = "Time: " + Time.timeSinceLevelLoad.ToString("F1");
	}

	public void GetNextGeneration(){
		generationStartTime = Time.timeSinceLevelLoad;
		float dogThing = (a+b*kittenPopulation)*doggiePopulation;
		float catThing = (c-d*doggiePopulation)*kittenPopulation;

		dogsToSpawn = (int)(dogThing - doggiePopulation);
		catsToSpawn = (int)(catThing - kittenPopulation);
		catsToSpawn = (Mathf.Abs(catsToSpawn) >= 1) ? catsToSpawn : 1;
		dogsToSpawn = (Mathf.Abs(dogsToSpawn) >= 1) ? dogsToSpawn : 1;
		catsSpawned = 0;
		dogsSpawned = 0;
	}

	public void SpawnDoggies(int numOfDoggies){
		if(doggiePopulation+numOfDoggies > maxDoggies){
			numOfDoggies = maxDoggies - doggiePopulation;
		}
		for(int k = 0; k < numOfDoggies; k++){
			Vector3 newPos = new Vector3(Random.Range(0f, Mathf.Abs(GameBounds.instance.width)), Random.Range(0f, Mathf.Abs(GameBounds.instance.height)), 0f);
			Instantiate(doggieObject, newPos, Quaternion.identity);
			doggiePopulation++;
		}	
	}

	public void SpawnDoggiesInRect(int numOfDoggies, Rect myRect){
		if(doggiePopulation+numOfDoggies > maxDoggies){
			numOfDoggies = maxDoggies - doggiePopulation;
		}
		for(int k = 0; k < numOfDoggies; k++){
			Vector3 newPos = new Vector3(myRect.min.x + Random.Range(0f, myRect.width), myRect.min.y + Random.Range(0f, myRect.height), 0f);
			Instantiate(doggieObject, newPos, Quaternion.identity);
			doggiePopulation++;
		}
	}

	public void SpawnKittens(int numOfKittens){
		if(kittenPopulation+numOfKittens > maxKittens){
			numOfKittens = maxKittens - kittenPopulation;
		}
		for(int k = 0; k < numOfKittens; k++){
			Vector3 newPos = new Vector3(Random.Range(0f, GameBounds.instance.width), Random.Range(0f, GameBounds.instance.height), 0f);
			Instantiate(kittenObject, newPos, Quaternion.identity);
			kittenPopulation++;
		}
	}

	public void RemoveDoggies(int numOfDoggies){
		if(numOfDoggies > doggiePopulation){
			numOfDoggies = doggiePopulation;
		}
		for(int k = 0; k < numOfDoggies; k++){
			if(doggiePopulation > 0){
				GameObject go = GameObject.FindWithTag("puppy");
				if(go != null){
					Destroy(go);
					doggiePopulation--;
				}
			}
		}
	}

	public void RemoveKittens(int numOfKittens){
		if(numOfKittens > kittenPopulation){
			numOfKittens = kittenPopulation;
		}
		for(int k = 0; k < numOfKittens; k++){
			GameObject go = GameObject.FindWithTag("kitten");
			if(go != null){
				Destroy(go);
				kittenPopulation--;
			}
		}
	}

	public float TotalPopulation(){
		return kittenPopulation + doggiePopulation;
	}

	public void DecrementDoggieCount(){
		doggiePopulation--;
	}
	public void DecrementKittenCount(){
		kittenPopulation--;
	}
}
