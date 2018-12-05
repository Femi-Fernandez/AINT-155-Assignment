/**********************************************************
 * 
 * WeaponManager.cs
 * - controls the weapon GameObjects belonging to the player
 * - weapons have to be children of the WeaponManager's GameObject
 * - the WeaponManager will activate one weapon at a time
 *  
 *   
 * public methods
 * - ChangeWeapon
 *   - changes the current weapon to the weapon specified by index
 *   - index refers to the weapon in the Hierarchy, from top to bottom
 *   - e.g. index 0 is at the top, index 1 is below etc
 *   - the current weapon's GameObject will be active, the rest will be deactivated
 *   - if the index is not present, the weapon will not be changed
 *   
 * - AddWeapon
 *   - adds a new weapon as a child of the WeaponManager from the provided prefab
 *   - the new weapon will be selected when added
 *   
 * 
 * private methods
 * - Start
 *   - changes the weapon to the first weapon in the WeaponManager
 *   
 * - Update
 *   - changes weapon by pressing number keys from 1-3
 * 
 * 
 **********************************************************/

using UnityEngine;

public class WeaponManager : MonoBehaviour
{

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

                    transform.GetChild(i).gameObject.SetActive(true);
                }
                else 
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }


    /*
     * AddWeapon
     * adds a new weapon as a child of the WeaponManager from the "prefab" parameter
     * the new weapon will be selected when added
     */
    public void AddWeapon(GameObject prefab)
    {
        /*
         * CREATE THE NEW WEAPON FROM THE prefab PARAMETER
         * we use Instantiate to create our new weapon
         * the weapon will be in the same position and roation as the WeaponManager
         * the WeaponManager's transform will be the parent of the weapon in the Hierarchy
         * see link: https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
         */
        GameObject weapon = Instantiate(prefab, transform.position, transform.rotation, transform);

        /*
         * CHANGE WEAPON TO THE NEW WEAPON
         * here, we get the current sibling index of the new weapon (where the weapon is in the Hierachy)
         * we change weapon to the current weapon's sibling index
         * NOTE: the sibling index get be obtined from its transform component
         * see link: https://docs.unity3d.com/ScriptReference/Transform.GetSiblingIndex.html
         */
        ChangeWeapon(weapon.transform.GetSiblingIndex());
    }

    private void Update()
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
