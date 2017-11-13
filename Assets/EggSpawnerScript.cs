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
            nextSpawn = Time.time + spawnRate;
            randx = Random.Range(-8.4f, 8.4f);
            whereToSpawn = new Vector2(randx, transform.position.y);
            Instantiate(Egg, whereToSpawn, Quaternion.identity);
        }
	}
}
