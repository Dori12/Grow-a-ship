using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStates : MonoBehaviour {

    public enum states { Nothing, EnterShop, Shop, ExitShop, EnterUpgrade, Upgrade, ExitUpgrade }

    public states currentState;

    public RectTransform ShopUItr;
    public RectTransform UpgradeUItr;

    public float speed;

    private Vector2 UIInitPos;

    private void Start()
    {
        currentState = states.Nothing;
        UIInitPos = ShopUItr.anchoredPosition;
    }

    private void Update()
    {
        UpgradeState();
        ShopState();
    }

    void UpgradeState()
    {
        switch (currentState)
        {
            case states.EnterUpgrade:
                if(DownUI(UpgradeUItr) == true)
                {
                    ChangeState(states.Upgrade);
                }
                break;
            case states.Upgrade:
                break;
            case states.ExitUpgrade:
                if(UpUI(UpgradeUItr) == true)
                {
                    ChangeState(states.Nothing);
                }
                break;
        }
    }

    void ShopState()
    {
        switch(currentState)
        {
            case states.EnterShop:
                if (DownUI(ShopUItr) == true)
                {
                    ChangeState(states.Shop);
                }
                break;
            case states.Shop:
                break;
            case states.ExitShop:
                if (UpUI(ShopUItr) == true)
                {
                    ChangeState(states.Nothing);
                }
                break;
        }
    }

    public void ChangeState(states changeState)
    {
        currentState = changeState;
    }

    bool DownUI(RectTransform ui)
    {
        ui.anchoredPosition =
                    Vector2.MoveTowards(ui.anchoredPosition, new Vector2(0.0f, 0.0f), speed);
        if (ui.anchoredPosition.y <= 0.0f)
        {
            ui.anchoredPosition = new Vector2(0.0f, 0.0f);
            return true;
        }
        return false;
    }

    bool UpUI(RectTransform ui)
    {
        ui.anchoredPosition =
                    Vector2.MoveTowards(ui.anchoredPosition, UIInitPos, speed);
        if (ui.anchoredPosition.y >= UIInitPos.y)
        {
            ui.anchoredPosition = UIInitPos;
            return true;
        }
        return false;
    }
}
