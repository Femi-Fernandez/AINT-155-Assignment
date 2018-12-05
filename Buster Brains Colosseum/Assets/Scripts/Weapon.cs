using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//[System.Serializable]
//public class onReloadEvent : UnityEvent<bool> { }
public class Weapon : WeaponBase
{
    
    public UnityEvent onReload;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;



    public int bulletMagazine = 30;
    public float reloadTime = 1.5f;
    public bool emptyMagazine = false;


    private bool isFiring = false;
	// Use this for initialization
	private void SetFiring()
    {
        isFiring = false;
    }
	
    private void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    private IEnumerator ReloadGun()
    {
            yield return new WaitForSeconds(reloadTime);   
            bulletMagazine = 30;       
            emptyMagazine = false;
            reloading = false;
        
    }

    //    Update is called once per frame
    void Update () {
        
        if (Input.GetMouseButton(0) && !emptyMagazine && !reloading)
        {
            if (!isFiring)
            {
              Fire();
               bulletMagazine = bulletMagazine - 1;
                if(bulletMagazine == 0)
                {
                    emptyMagazine = true;
                    
                }
            }            
        }

        if (Input.GetKeyDown("r") && !reloading)
        {
            emptyMagazine = true;
            reloading = true;
            StartCoroutine(ReloadGun());
            onReload.Invoke();
            //  onReload.Invoke(true);
        }

    }
}
