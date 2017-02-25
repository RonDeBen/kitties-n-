using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PupBox : MonoBehaviour {
    public Rect myRect;

    public void DrawEndAction()
    {
        SpawnPuppies();
    }

    public void SpawnPuppies(){
    	float animalDensity = PopulationManager.instance.TotalPopulation() / GameBounds.instance.Area();
    	float myVolume = myRect.width * myRect.height;
    	int numPuppies = (int)(myVolume * animalDensity);
    	PopulationManager.instance.SpawnDoggies(numPuppies);
    }
}
