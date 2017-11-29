using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawnerScript : MonoBehaviour {


    public GameObject Egg;
    float randx;
    Vector2 whereToSpawn; 
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Time.time > nextSpawn)
        {
            if (Random.Range(0,100) <= 80)
            {
                spawnEgg();
            }
            nextSpawn = Time.time + spawnRate;

        }
	}

    void FixedUpdate()
    {
        spawnRate -= 0.00005f;
    }

    void spawnEgg()
    {
        whereToSpawn = new Vector2(transform.position.x, transform.position.y);
        Instantiate(Egg, whereToSpawn, Quaternion.identity);
    }
}
