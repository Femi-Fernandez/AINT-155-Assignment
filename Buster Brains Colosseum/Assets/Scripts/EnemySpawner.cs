using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject ZombiePrefab;
    public Transform zombieSpawner;
    //public int respawnTimer = 3;
    //private bool canSpawnEnemy = true;
    public int numOfZombies;
    public float spawnWait;
    public float startWait;
    public float waveWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnZombies());
	}
	
    IEnumerator SpawnZombies ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < numOfZombies; i++)
            {
                Instantiate(ZombiePrefab, zombieSpawner.position, zombieSpawner.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            numOfZombies += 1;
        }
    }


    //private IEnumerator Spawnenemy()
    //{
    //    yield return new WaitForSeconds(respawnTimer);
    //    Instantiate(ZombiePrefab, zombieSpawner.position, zombieSpawner.rotation);
    //    canSpawnEnemy = true;
    //}
	//// Update is called once per frame
	//void Update () {
    //    if (canSpawnEnemy == true)
    //    {
    //        StartCoroutine(Spawnenemy());
    //        canSpawnEnemy = false;
    //    }
	//}
}
