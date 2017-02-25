using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopulationManager : MonoBehaviour {

	public GameObject kittenObject, doggieObject;
	public float kittenKonstant, aggressionConstant, dogConstant, generationTime;

	private Stack<GameObject> kittenStack, doggieStack;

	private float catVelocity;

	private float nextSpawn;
	private int kittenPopulation, doggiePopulation;

	// Use this for initialization
	void Start () {
		// SpawnKittens(GameManager.instance.startDoggies);
		// SpawnDoggies(GameManager.instance.startKittens);
		kittenStack = new Stack<GameObject>();
		doggieStack = new Stack<GameObject>();
		SpawnKittens(10);
		SpawnDoggies(10);
		nextSpawn = Time.time + generationTime;
	}
	
	// Update is called once per frame
	void Update(){
		if(Time.time > nextSpawn){
			nextSpawn = Time.time + generationTime;
			SpawnNextGeneration();
		}
	}

	public float deltaKitten(){
		return 100 - kittenPopulation;
	}

	public void SpawnNextGeneration(){
		Debug.Log("number of cats: " + kittenPopulation);
		Debug.Log("number of dogs: " + doggiePopulation);
		catVelocity = kittenKonstant*deltaKitten()+aggressionConstant*(kittenPopulation - doggiePopulation);

		if(catVelocity > 0){
			SpawnKittens((int)catVelocity);
		}else{ 
			RemoveKittens((int)catVelocity);
		}
		SpawnDoggies((int)(doggiePopulation * dogConstant));
	}

	void SpawnDoggies(int numOfDoggies){
		doggiePopulation += numOfDoggies;
		for(int k = 0; k < numOfDoggies; k++){
			Vector3 newPos = new Vector3(Random.Range(0f, GameBounds.instance.width), Random.Range(0f, GameBounds.instance.height), 0f);
			doggieStack.Push(Instantiate(doggieObject, newPos, Quaternion.identity));
		}
	}

	void SpawnKittens(int numOfKittens){
		kittenPopulation += numOfKittens;
		for(int k = 0; k < numOfKittens; k++){
			Vector3 newPos = new Vector3(Random.Range(0f, GameBounds.instance.width), Random.Range(0f, GameBounds.instance.height), 0f);
			kittenStack.Push(Instantiate(kittenObject, newPos, Quaternion.identity));
		}
	}

	// void RemoveDoggies(int numOfDoggies){
	// 	for(int k = 0; k < numOfDoggies; k++){
	// 		GameObject obj = doggieStack.Pop();
	// 		if(obj != null){
	// 			Destroy(obj);
	// 		}
	// 	}
	// }

	void RemoveKittens(int numOfKittens){
		kittenPopulation -= numOfKittens;
		for(int k = 0; k < numOfKittens; k++){
			GameObject obj = kittenStack.Pop();
			if(obj != null){
				Destroy(obj);
			}
		}
	}
}
