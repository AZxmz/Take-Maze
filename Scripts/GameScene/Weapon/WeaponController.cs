using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;

    public TankBase weaponOwner; 
    public Transform[] shootPosition;


    void Start()
    {

    }


    void Update()
    {

    }

    public void SetOwner(TankBase tank)
    {
        weaponOwner = tank;
    }

    public void Shoot()
    {
        for (int i = 0; i < shootPosition.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPosition[i].transform.position, shootPosition[i].transform.rotation);
            BulletController bulletObj = obj.GetComponent<BulletController>();
            bulletObj.SetOwner(weaponOwner);

        }
    }
}
