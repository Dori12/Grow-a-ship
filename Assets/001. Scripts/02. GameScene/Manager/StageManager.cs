using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public static StageManager Instance;

    public int _stage { get; private set; } // 현재 스테이지
    private int _catchEnemyNumInStage; // 현재 스테이지에서 잡은 적의 수
    [SerializeField] private int _catchEnemyLimit; // 잡아야할 목표 적의 수
    public bool _isBossStage { get; private set; } // 현재 보스를 잡는 중인가?
    private bool _catchBoss; // 보스를 잡았는가?
    public bool _isCatchBossFailed { get; private set; } // 현재 진행중인 스테이지의 보스를 잡는데 실패했는가?
    private float _bossTimer; //보스 타이머
    [SerializeField] private float _bossTimeLimit; //보스 타임 리미트

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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

        if (_catchEnemyNumInStage >= _catchEnemyLimit)
        {
            _isBossStage = true;
        }
    }

    void CatchBossForUpdate()
    {
        if (_isBossStage == false)
            return;

        _bossTimer += Time.deltaTime;
        if (_bossTimer < _bossTimeLimit)
        {
            if (_catchBoss == true)
            {
                _isBossStage = false;
                _isCatchBossFailed = false;
                _stage++;
                InitEnemyNum();
            }
        }
        else
        {
            _isBossStage = false;
            _isCatchBossFailed = true;
            _catchBoss = false;
            InitEnemyNum();
        }
    }

    public void CatchEnemy()
    {
        _catchEnemyNumInStage++;
    }

    public void InitEnemyNum()
    {
        _catchEnemyNumInStage = 0;
    }

}