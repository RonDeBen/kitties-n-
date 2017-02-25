using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
/// <summary>
/// The box that removes animabls from the scene
/// </summary>
public class ShoeBox : MonoBehaviour {

    public float speed = 20f;

    public void DrawEndAction()
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f, 1<<8);
        int kittenCount = 0;
        int puppyCount = 0;
        foreach(Collider2D pet in colls)
        {
            pet.transform.parent = transform;
            pet.GetComponent<RandomMovement>().enabled = false;
            if (pet.tag.Equals("kitten"))
                kittenCount++;
            else
                puppyCount++;
        }
        //TODO: change the population totals using the counts
        StartCoroutine(FindThemAHome());
    }

    IEnumerator FindThemAHome()
    {
        yield return null;
        while(!Mathf.Approximately(transform.position.y, -10f))
        {
            transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, -10f, speed * Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
