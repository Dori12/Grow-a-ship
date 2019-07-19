using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJapanShip : JapanShip {

	// Use this for initialization
	void Start () {
        currentState = states.Arrive;
        _InitPos = transform.position;
        _animator.GetComponent<Animator>();
        _animator.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        StateActionForUpdate();
	}

    public override void StateActionForUpdate()
    {
        base.StateActionForUpdate();
    }

    public override void ArriveAction()
    {
        HPSYSTEM.SetStageHp(StageManager.Instance._stage);
        HPSYSTEM.SetHp();
        SwitchSprite();
        ColorInit();
        hpBar.SetActive(true);
        currentState = states.Idle;
    }

    public override void IdleAction()
    {
        if (HPSYSTEM.currentHp <= 0.0d)
        {
            currentState = states.Dying;
        }
    }

    public override void DieAction()
    {
        if (!StageManager.Instance.isCatchBoss())
        {
            StageManager.Instance.CatchBoss();
        }
        gameObject.SetActive(false);
    }

    public override void DyingAction()
    {
        hpBar.SetActive(false);
        if (FadeOut())
        {
            currentState = states.Die;
        }
    }

    
}
