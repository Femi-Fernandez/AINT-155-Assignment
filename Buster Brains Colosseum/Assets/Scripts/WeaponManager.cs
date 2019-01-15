using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{

    WeaponBase currentWeapon;

    void Start()
    {
        ChangeWeapon(0);
    }

    public void ChangeWeapon(int index)
    {

        if (index < transform.childCount)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == index)
                {
                    currentWeapon = transform.GetChild(i).GetComponent<WeaponBase>();
                    transform.GetChild(i).gameObject.SetActive(true);
                    print(currentWeapon);
                }
                else 
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }



    public void AddWeapon(GameObject prefab)
    {

        GameObject weapon = Instantiate(prefab, transform.position, transform.rotation, transform);

        ChangeWeapon(weapon.transform.GetSiblingIndex());
    }

    private void Update()
    {
        
        if (currentWeapon.reloading == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeWeapon(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeWeapon(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeWeapon(2);
            }
        }
                  
    }
}
