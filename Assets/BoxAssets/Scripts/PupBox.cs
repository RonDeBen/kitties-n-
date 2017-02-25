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
    	float myVolume = Mathf.Abs(myRect.width) * Mathf.Abs(myRect.height);
    	int numPuppies = (int)(myVolume * animalDensity);
    	PopulationManager.instance.SpawnDoggiesInRect(numPuppies, myRect);
    	Destroy(gameObject);
    }
}
