using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    public static RefactoredObstacleSpawner Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    [SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;

    protected override void Start()
    {
        base.Start();
        RefactoredGameController.OnGameOverActions += OnGameOver;
    }

    protected override void SpawnObject()
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                GameObject OBJ = obstacleLowPool.GetOBJ();
                OBJ.transform.position = new Vector2(Random.Range(MinX, MaxX), YPos);

                break;
            case 1:
                GameObject OBJ2 = obstacleMidPool.GetOBJ();
                OBJ2.transform.position = new Vector2(Random.Range(MinX, MaxX), YPos);
                break;
            case 2:
                GameObject OBJ3 = obstacleHardPool.GetOBJ();
                OBJ3.transform.position = new Vector2(Random.Range(MinX, MaxX), YPos);
                break;
        }
    }
}

