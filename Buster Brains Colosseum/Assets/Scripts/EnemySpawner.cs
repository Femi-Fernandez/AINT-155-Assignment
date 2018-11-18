using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject ZombiePrefab;
    public Transform zombieSpawner;
    public int respawnTimer = 3;
    private bool canSpawnEnemy = true;

	// Use this for initialization
	void Start () {
		
	}
	
    private IEnumerator Spawnenemy()
    {
        yield return new WaitForSeconds(respawnTimer);
        Instantiate(ZombiePrefab, zombieSpawner.position, zombieSpawner.rotation);
        canSpawnEnemy = true;
    }
	// Update is called once per frame
	void Update () {
        if (canSpawnEnemy == true)
        {
            StartCoroutine(Spawnenemy());
            canSpawnEnemy = false;
        }
	}
}
