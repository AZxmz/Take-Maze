using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敵の管理
/// </summary>
public class EnemyTank : TankBase
{
    public Transform[] shootPosition;
    public GameObject bullet;

    public GameObject[] rewards;

    public Texture maxHpBg;
    public Texture hpBg;

    //ヘルスバータイマーを表示する
    private float HPshowTime = 0;


    private Rect maxHpRect;
    private Rect hpRect;



    public Transform targetPosition;
    public Transform[] targetPositions;
    public Transform playerPosition;

    public float firDistance;
    public float fireTime;
    private float currentFireTime;


    void Start()
    {
        GetRandomPosition();
    }


    void Update()
    {

        this.transform.LookAt(targetPosition);
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //移動点までの距離を計算し。距離が十分に小さい場合は、移動点を変更します。
        if (Vector3.Distance(this.transform.position, targetPosition.position) < 0.05f)
        {
            GetRandomPosition();
        }

        if (playerPosition != null)
        {
            headObject.transform.LookAt(playerPosition);
            if (Vector3.Distance(this.transform.position, playerPosition.position) <= firDistance)
            {
                currentFireTime += Time.deltaTime;
                if (currentFireTime >= fireTime)
                {
                    Fire();
                    currentFireTime = 0;
                }
            }

        }
        
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPosition.Length; i++)
        {
            GameObject bulletObj = Instantiate(bullet, shootPosition[i].position, shootPosition[i].rotation);
            BulletController bulletController = bulletObj.GetComponent<BulletController>();
            //属性計算を容易にするために所有者IDを設定する
            bulletController.SetOwner(this);
        }
    }

    public override void Dead()
    {
        base.Dead();

        GamePanel.Instance.UpdateScore(10);
        //ランダム報酬
        for (int i = 0; i < rewards.Length; i++)
        {
            int random = Random.Range(0, 101);
            if (random <= 70)
            {
                Instantiate(rewards[i], this.transform.position, this.transform.rotation);
            }
        }
    }

    private void GetRandomPosition()
    {

        targetPosition = targetPositions[Random.Range(0, targetPositions.Length)];

    }


    private void OnGUI()
    {
        if (HPshowTime > 0)
        {

            HPshowTime -= Time.deltaTime;


            //現在の位置を画面位置に変換         
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //UIの位置に変換する
            screenPos.y = Screen.height - screenPos.y;

            //ヘルスバー表示の偏差を計算する
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect, maxHpBg);

            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;

            hpRect.width = (float)currentHP / maxHP * 100f;
            hpRect.height = 15;
            GUI.DrawTexture(hpRect, hpBg);
        }
    }

 
    public override void GetInjured(TankBase other)
    {
        base.GetInjured(other);
        //HPshowTime = 3;
    }

}
