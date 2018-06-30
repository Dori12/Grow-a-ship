using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public UIStates uiStates;
    public Text stageText;

    public void EnterUpgrade()
    {
        if(UIStates.states.Nothing == uiStates.currentState)
            uiStates.ChangeState(UIStates.states.EnterUpgrade);
    }

    public void ExitUpgrade()
    {
        if (UIStates.states.Upgrade == uiStates.currentState)
            uiStates.ChangeState(UIStates.states.ExitUpgrade);
    }

    public void EnterShop()
    {
        if (UIStates.states.Nothing == uiStates.currentState)
            uiStates.ChangeState(UIStates.states.EnterShop);
    }

    public void ExitShop()
    {
        if (UIStates.states.Shop == uiStates.currentState)
            uiStates.ChangeState(UIStates.states.ExitShop);
    }
    
    public void RenewalStageText()
    {
        int currentStage = StageManager.Instance._stage;
        stageText.text = "스테이지 : " + currentStage.ToString();
    }
}
