using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponBase
{


    public GameObject meleePrefab;
    public Transform meleeSpawn;
    public SpriteRenderer spriteRenderer;

    public float swingTime = 0.5f;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0) && reloading == false)
        {           
            Fire(); 
            reloading = true;
            spriteRenderer.enabled = false;
            StartCoroutine(swingDownTime());
        }
    }
}
