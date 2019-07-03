using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoreaShip : MonoBehaviour {

    Sprite bulletSprite;
    public ResourceManager _resourceManager;
    public Transform shotPos;
    public GameObject bullet;

    public double atk;

    private void Awake()
    {
        _resourceManager = FindObjectOfType<ResourceManager>();
    }
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
        int num = _resourceManager._bulletSprites.Length;

        if(i > num)
        {
            Debug.LogError("Bullet Num Warning");
        }

        bulletSprite = _resourceManager._bulletSprites[i];
    }
}
