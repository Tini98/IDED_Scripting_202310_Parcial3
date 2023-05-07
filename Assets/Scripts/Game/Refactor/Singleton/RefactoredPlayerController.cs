using System;
using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    public static RefactoredPlayerController Instance { get; private set; } = null;

    public static Action<int> UI_IconAction;

    private PoolBase _pool;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();

        RefactoredGameController.OnGameOverActions += OnGameOver;
        RefactoredGameController.Player_ChangeScore += UpdateScore;
    }

    protected override bool NoSelectedBullet => _pool == null;

    protected override void Shoot()
    {
        GameObject G = _pool.GetOBJ();
        if (G != null)
        {
            G.transform.position = spawnPos.position;
            G.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Force);
        }
    }

    protected override void SelectBullet(int index)
    {

        switch (index)
        {
            case 0:
                _pool = PoolLowBullet.Instance;
                break;

            case 1:
                _pool = PoolMidBullet.Instance;
                break;

            case 2:
                _pool = PoolHardBullet.Instance;
                break;
        }

        if (UI_IconAction != null)
            UI_IconAction(index);

    }

    private void OnScoreChangeEvent(int scoreAdd) //esta :)
    {
        
    }

}