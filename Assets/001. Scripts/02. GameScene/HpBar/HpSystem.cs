using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSystem : MonoBehaviour {

    public double currentHp; //현재 Hp
    public double maxHp; //최대 Hp
    public double InitHp; // 1랩 최소 Hp
    public double stageUpNum; // 스테이지 오를때 배율
    public int bossUpHp;
    static public double stageHp;
    [SerializeField] private bool isBoss;


    private void Update()
    {
    }

    public void SetStageHp(int _stage)
    {
        stageHp = 1.0d;
        for(int i=0; i<_stage; i++)
        {
            stageHp *= stageUpNum;
        }
        if(isBoss)
        {
            stageHp *= bossUpHp;
        }
    }
    public void SetHp()
    {
        maxHp = InitHp * stageHp;
        currentHp = maxHp;
    }
    public double remainHpPercent()
    {
        return currentHp / maxHp;
    }

    public void TakeDamage(double _damage)
    {
        currentHp -= _damage;
        if(currentHp < 0.0d)
        {
            currentHp = 0.0d;
        }
    }
}
