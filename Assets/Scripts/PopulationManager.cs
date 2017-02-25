﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopulationManager : MonoBehaviour {

	public GameObject kittenObject, doggieObject;
	public Text kittenText, doggieText, timeText;
	public float a, b, c, d, generationTime;
	public int hackStartDog, hackStartCat;

	private Stack<GameObject> kittenStack, doggieStack;

	private float catsToSpawn, dogsToSpawn, dogsSpawned, catsSpawned, generationStartTime;

	private float nextSpawn;
	private int kittenPopulation, doggiePopulation;

	// Use this for initialization
	void Start () {
		kittenStack = new Stack<GameObject>();
		doggieStack = new Stack<GameObject>();
		SpawnKittens(hackStartCat);
		SpawnDoggies(hackStartDog);
		nextSpawn = Time.time + generationTime;
	}
	
	// Update is called once per frame
	void Update(){
		if(Time.time > nextSpawn){
			nextSpawn = Time.time + generationTime;
			GetNextGeneration();
		}
		LerpAnimals();
	}

	public void LerpAnimals(){
		float percentage = (nextSpawn-Time.time)/generationTime;
		if(catsToSpawn > 0){//positive change
			float kittenSpawnThisCycle = Mathf.Lerp(0f, catsToSpawn, percentage) - catsSpawned;
			catsSpawned += kittenSpawnThisCycle;
			SpawnKittens((int)kittenSpawnThisCycle);
		}else{//negative change
			float kittenRemoveThisCycle = -(Mathf.Lerp(0f, catsToSpawn, percentage) + catsSpawned);
			catsSpawned += kittenRemoveThisCycle;//should really be catsRemoved
			RemoveKittens((int)kittenRemoveThisCycle);
		}

		if(dogsToSpawn > 0){//positive change
			float doggiesSpawnThisCycle = Mathf.Lerp(0f, dogsToSpawn, percentage) - dogsSpawned;
			dogsSpawned += doggiesSpawnThisCycle;
			SpawnDoggies((int)doggiesSpawnThisCycle);
		}else{//negative change
			float doggiesRemoveThisCycle = -(Mathf.Lerp(0f, dogsToSpawn, percentage) + dogsSpawned);
			dogsSpawned += doggiesRemoveThisCycle;//should really be dogsRemoved
			RemoveDoggies((int)doggiesRemoveThisCycle);
		}

		kittenText.text = "Number of Kittens: " + kittenPopulation.ToString();
		doggieText.text = "Number of Puppies: " + doggiePopulation.ToString();
		timeText.text = "Time: " + Time.time.ToString("F1");
	}

	public void GetNextGeneration(){
		float dogThing = (a+b*kittenPopulation)*doggiePopulation;
		float catThing = (c-d*doggiePopulation)*kittenPopulation;
		dogsToSpawn = dogThing - doggiePopulation;
		catsToSpawn = catThing - kittenPopulation;
		catsSpawned = 0;
		dogsSpawned = 0;
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

	void RemoveDoggies(int numOfDoggies){
		if(numOfDoggies > doggiePopulation){
			numOfDoggies = doggiePopulation;
		}
		doggiePopulation -= numOfDoggies;
		for(int k = 0; k < numOfDoggies; k++){
			GameObject obj = doggieStack.Pop();
			if(obj != null){
				Destroy(obj);
			}
		}
	}

	void RemoveKittens(int numOfKittens){
		if(numOfKittens > kittenPopulation){
			numOfKittens = kittenPopulation;
		}
		kittenPopulation -= numOfKittens;
		for(int k = 0; k < numOfKittens; k++){
			GameObject obj = kittenStack.Pop();
			if(obj != null){
				Destroy(obj);
			}
		}
	}
}
