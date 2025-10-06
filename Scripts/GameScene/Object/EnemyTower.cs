using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の砲塔管理
/// </summary>
public class EnemyTower : TankBase
{
    public GameObject bullet;
    private float currentShootTime;
    public float shootTime;

    public Transform[] shootPositions;



    void Update()
    {
        currentShootTime += Time.deltaTime;
        if (currentShootTime >= shootTime)
        {
            Fire();
            currentShootTime = 0;
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPositions.Length; i++)
        {
            GameObject bulletObj = Instantiate(bullet, shootPositions[i].position, shootPositions[i].rotation);
            BulletController bulletController = bulletObj.GetComponent<BulletController>();
            bulletController.SetOwner(this);
        }
    }

    public override void GetInjured(TankBase attackTank)
    {
        //塔は破壊されない
    }
}
