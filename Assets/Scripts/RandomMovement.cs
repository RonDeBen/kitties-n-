using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is a modified version of the script aldonaletto posted to http://answers.unity3d.com/questions/183465/random-movement-in-2d.html
 */

public class RandomMovement : MonoBehaviour {

    public float moveSpeed = 1;
    public float maxTimeToTurn = 1.2f;
    public float minTimeToTurn = 0.3f;

    public static Rect screenSpace = Rect.zero;

    private float tChange = 0; // force new direction in the first Update
    private float randomX;
    private float randomY;
    private SpriteRenderer sprender;

    void Start()
    {
        screenSpace = new Rect(0f, 0f, GameBounds.instance.width, GameBounds.instance.height);
        sprender = gameObject.GetComponent<SpriteRenderer>();
    }
 
 void Update()
    {
        // change to random direction at random intervals
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-2.0f, 2.0f); // with float parameters, a random float
            randomY = Random.Range(-2.0f, 2.0f); //  between -2.0 and 2.0 is returned
                                               // set a random interval between 0.5 and 1.5
            if(randomX > 0){//going right
                sprender.flipX = false;
            }else{
                sprender.flipX = true;
            }
            tChange = Time.time + Random.Range(minTimeToTurn, maxTimeToTurn);
        }
        transform.Translate(new Vector3(randomX, randomY, 0) * moveSpeed * Time.deltaTime);
        // if object reached any border, revert the appropriate direction
        if (transform.position.x >= screenSpace.xMax || transform.position.x <= screenSpace.xMin)
        {
            randomX = -randomX;
        }
        if (transform.position.y >= screenSpace.yMax || transform.position.y <= screenSpace.yMin)
        {
            randomY = -randomY;
        }
        // make sure the position is inside the borders
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, screenSpace.xMin, screenSpace.xMax), 
            Mathf.Clamp(transform.position.y, screenSpace.yMin, screenSpace.yMax));
    }

 
}
