using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    //Lists of weapon parts
    public List<GameObject> bodyParts;
    public List<GameObject> scopeParts;
    public List<GameObject> magazineParts;
    public List<GameObject> stockParts;
    public List<GameObject> barrelParts;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("Body(Clone)") != null)
            {
                Destroy(GameObject.Find("Body(Clone)").gameObject);
                //destroy the body with children
            }
            GenerateRandomWeapon();
        }

    }

    void GenerateRandomWeapon()
    {
        GameObject randomBody = GetRandomPart(bodyParts); //Generate the Body of weapon
        GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity); //Spawn the Body
        WeaponBody wpnBody = insBody.GetComponent<WeaponBody>(); //Get reference of Sockets from WeaponBody Component
        StatCheck staBody = insBody.GetComponent<StatCheck>(); //Get reference

        //Spawn the other parts of weapon
        SpawnRandomWeaponPart(scopeParts, wpnBody.ScopeSocket);
        SpawnRandomWeaponPart(magazineParts, wpnBody.MagazineSocket);
        SpawnRandomWeaponPart(stockParts, wpnBody.StockSocket);
        SpawnRandomWeaponPart(barrelParts, wpnBody.BarrelSocket);


        staBody.CheckStat();//check statistics of the weapon (damage, accuracy and ammo)
    }

    void SpawnRandomWeaponPart(List<GameObject> parts, Transform socket)
    {
        //select random part of weapon
        GameObject randomPart = GetRandomPart(parts);

        //spawn the part in Socket position
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);

        //set the part as child of the socket
        insPart.transform.parent = socket;
    }
     
    GameObject GetRandomPart(List<GameObject> partList)
    {
        //random parts generator
        int randomNumber = Random.Range(0, partList.Count);
        return partList[randomNumber];
    }
}
