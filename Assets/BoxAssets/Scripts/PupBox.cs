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
        if(numPuppies < 1)
            numPuppies =1;
    	PopulationManager.instance.SpawnDoggiesInRect(numPuppies, myRect);
        PopulationManager.instance.ReleaseDoggies(numPuppies);
    	Destroy(gameObject);
    }
}
