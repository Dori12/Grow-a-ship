using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JapanShip : MonoBehaviour {

    public enum states { Idle, Dying, Die, Arrive }

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected GameObject hpBar;
    [SerializeField] protected Animator _animator;

    public static Vector2 _InitPos;

    protected ResourceManager _resourceManager;
    
    public HpSystem HPSYSTEM;
    public float fadeOutSpeed;
    

    public states currentState;

    // Use this for initialization
    private void Awake()
    {
        _resourceManager = FindObjectOfType<ResourceManager>();
    }

    public void SwitchSprite()
    {
        _animator.runtimeAnimatorController = _resourceManager._japanAnimator[Random.Range(0, _resourceManager._japanAnimator.Length)];
    }

    public virtual void StateActionForUpdate()
    {
        switch (currentState)
        {
            case states.Arrive:
                ArriveAction();
                break;
            case states.Idle:
                IdleAction();
                break;
            case states.Dying:
                DyingAction();
                break;
            case states.Die:
                DieAction();
                break;
        }
    }
    public virtual void ArriveAction()
    {

    }

    public virtual void IdleAction()
    {

    }

    public virtual void DyingAction()
    {

    }

    public virtual void DieAction()
    {

    }
    public bool FadeOut()
    {
        if(spriteRenderer.color.a > 0.0f)
        {
            spriteRenderer.color -= new Color(0.0f, 0.0f, 0.0f, fadeOutSpeed * Time.deltaTime);
        }
        else
        {
            return true;
        }
        return false;
    }

    public void ColorInit()
    {
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
