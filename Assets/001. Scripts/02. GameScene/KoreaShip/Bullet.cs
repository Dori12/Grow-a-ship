using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public double atk;
    public float speed;

    public GameObject bossShip;
    public GameObject commonShip;

    private void Start()
    {
        bossShip = GameObject.FindWithTag("BossShip");
        commonShip = GameObject.FindWithTag("CommonShip");
    }
    void Update () {
        FlyBulletForUpdate();
	}

    void FlyBulletForUpdate()
    {
        transform.Translate(+speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > JapanShip._InitPos.x)
        {
            if (bossShip)
            {
                bossShip.GetComponent<JapanShip>().HPSYSTEM.TakeDamage(atk);
                Destroy(gameObject);
            }
            else if(commonShip)
            {
                commonShip.GetComponent<JapanShip>().HPSYSTEM.TakeDamage(atk);
                Destroy(gameObject);
            }
        }
    }
}
