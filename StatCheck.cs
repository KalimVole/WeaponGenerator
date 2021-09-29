using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCheck : MonoBehaviour
{
    public int damage;
    public int accuracy;
    public int ammo;

    public void CheckStat()
    {
        //check all children and count the bonuses

        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            PartStats s = child.GetComponent<PartStats>();
            if (s != null)
            {
                damage += s.damageBonus;
                accuracy += s.accuracyBonus;
                ammo += s.ammoBonus;
            }
        }
        Debug.Log("Damage: " + damage + " Accuracy: " + accuracy + " Ammo: " + ammo);
    }
}
