using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public static StageManager Instance;

    [SerializeField] private int _catchEnemyLimit; // 잡아야할 목표 적의 수
    [SerializeField] private bool _catchBoss; // 보스를 잡았는가?
    [SerializeField] private float _bossTimeLimit; //보스 타임 리미트
    [SerializeField] private GameObject _goBossShip;
    [SerializeField] private GameObject _goCommonShip;
    

    public int _stage  // 현재 스테이지
    {
        get;
        private set;
    }

    public bool _isBossStage  // 현재 보스를 잡는 중인가?
    {
        get;
        private set;
    }
    
    public bool _isCatchBossFailed  // 현재 진행중인 스테이지의 보스를 잡는데 실패했는가?
    {
        get;
        private set;
    }

    private int _catchEnemyNumInStage; // 현재 스테이지에서 잡은 적의 수
    private float _bossTimer; //보스 타이머
    private UIManager _uiManager;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _uiManager = FindObjectOfType<UIManager>();
    }
    // Use this for initialization
    void Start()
    {
        _stage = PlayerPrefs.GetInt("_stage", 1);
        _uiManager.RenewalStageText();
    }

    // Update is called once per frame
    void Update()
    {
        ArriveBossForUpdate();
        CatchBossForUpdate();
    }

    void ArriveBossForUpdate()
    {
        if (_isCatchBossFailed == true)
            return;

        if (_isBossStage == true)
            return;

        if (_catchEnemyNumInStage >= _catchEnemyLimit)
        {
            _isBossStage = true;
            _goBossShip.SetActive(true);
            _goBossShip.GetComponent<JapanShip>().currentState = JapanShip.states.Arrive;
            _goCommonShip.SetActive(false);
            _bossTimer = _bossTimeLimit;
        }
    }

    void CatchBossForUpdate()
    {
        if (_isBossStage == false)
            return;

        if (_goBossShip.GetComponent<JapanShip>().currentState == JapanShip.states.Idle)
        {
            _bossTimer -= Time.deltaTime;
        }

        if (_bossTimer > 0.0f)
        {
            if (_catchBoss == true)
            {
                BossEnd();
                _stage++;
                _uiManager.RenewalStageText();
                _isCatchBossFailed = false;
            }
        }
        else
        {
            BossEnd();
            _goBossShip.GetComponent<JapanShip>().currentState = JapanShip.states.Dying;
            _isCatchBossFailed = true;
        }
    }

    void BossEnd()
    {
        _isBossStage = false;
        _catchBoss = false;
        InitEnemyNum();
        _goCommonShip.SetActive(true);
        _goCommonShip.GetComponent<JapanShip>().currentState = JapanShip.states.Arrive;
        _bossTimer = 0.0f;
    }

    public void CatchEnemy()
    {
        _catchEnemyNumInStage++;
    }

    public int CatchEnemyNum()
    {
        return _catchEnemyNumInStage;
    }

    public void InitEnemyNum()
    {
        _catchEnemyNumInStage = 0;
    }

    public void CatchBoss()
    {
        _catchBoss = true;
    }

    public bool isCatchBoss()
    {
        return _catchBoss;
    }

}