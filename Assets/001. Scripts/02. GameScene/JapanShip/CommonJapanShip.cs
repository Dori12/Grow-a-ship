﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonJapanShip : JapanShip
{
	// Use this for initialization
	void Start () {
        currentState = states.Arrive;
        _InitPos = transform.position;
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
        hpBar.SetActive(true);
        HPSYSTEM.SetStageHp(StageManager.Instance._stage);
        HPSYSTEM.SetHp();
        SwitchSprite();
        ColorInit();
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
        hpBar.SetActive(false);
        if(!StageManager.Instance._isBossStage)
        {
            currentState = states.Arrive;
        }
    }

    public override void DyingAction()
    {
        if (FadeOut())
        {
            currentState = states.Die;
            StageManager.Instance.CatchEnemy();
        }
    }
}