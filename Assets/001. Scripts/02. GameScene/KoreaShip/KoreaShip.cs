using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoreaShip : MonoBehaviour {

    Sprite bulletSprite;
    public ResourceManager RESOURCEMANAGER;
    public Transform shotPos;
    public GameObject bullet;

    public double atk;

	// Use this for initialization
	void Start () {
        SelectBulletSprite(3);
	}
	
	// Update is called once per frame
	void Update () {
        TapShotForUpdate();
	}
    
    void TapShotForUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        GameObject bulletObj = Instantiate(bullet, shotPos.position, Quaternion.identity);
        bulletObj.GetComponent<SpriteRenderer>().sprite = bulletSprite;
    }

    void SelectBulletSprite(int i)
    {
        int num = RESOURCEMANAGER._bulletSprites.Length;
        if(i > num)
        {
            Debug.LogError("Bullet Num Warning");
        }
        bulletSprite = RESOURCEMANAGER._bulletSprites[i];
    }
}
