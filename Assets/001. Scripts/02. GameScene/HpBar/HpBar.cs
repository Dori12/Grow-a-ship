using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public HpSystem targetHpSystem;
    public Image gauge;
	
	// Update is called once per frame
	void Update () {
        gauge.fillAmount = (float)targetHpSystem.remainHpPercent();
	}
}
