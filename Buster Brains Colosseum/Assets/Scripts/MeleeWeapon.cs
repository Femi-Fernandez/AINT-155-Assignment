using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponBase
{


    public GameObject meleePrefab;
    public Transform meleeSpawn;
    

    public float swingTime = 0.5f;

    // Use this for initialization
    void Start () {

    }

    private void Fire()
    {

        Instantiate(meleePrefab, meleeSpawn.position, meleeSpawn.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator swingDownTime()
    {
        yield return new WaitForSeconds(swingTime);
        reloading = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0) && reloading == false)
        {           
            Fire();
            reloading = true;
            StartCoroutine(swingDownTime());
        }
    }
}
