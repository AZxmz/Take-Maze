using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player管理
/// </summary>
public class PlayerTank : TankBase
{
    public WeaponController currentWeapon;
    public Transform weaponPosition;

    void Update()
    {
        
        this.transform.Translate(Vector3.forward * moveSpeed
                        * Input.GetAxis("Vertical") * Time.deltaTime);
        this.transform.Rotate(Vector3.up * rotateSpeed
                        * Input.GetAxis("Horizontal") * Time.deltaTime);

        headObject.transform.Rotate(Vector3.up * headRotateSpeed
                        * Input.GetAxis("Mouse X") * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        base.Fire();
        if (currentWeapon != null)
        {
            currentWeapon.Shoot();
        }

    }

    public override void GetInjured(TankBase attackTank)
    {
        base.GetInjured(attackTank);
        GamePanel.Instance.UpdateHp(this.currentHP, this.maxHP);
    }

    public override void Dead()
    {
        Time.timeScale = 0;
        
        LosePanel.Instance.Show();
    }

    public void ChangeWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
            currentWeapon = null;
        }
        GameObject weaponObj = Instantiate(weapon, weaponPosition, false);
        currentWeapon = weaponObj.GetComponent<WeaponController>();

        currentWeapon.SetOwner(this);
    }
}
