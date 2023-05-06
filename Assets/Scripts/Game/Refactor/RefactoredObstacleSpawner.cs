using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    /*[SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;

    protected override void SpawnObject()
    {
        throw new System.NotImplementedException();
    }*/


    private static RefactoredObstacleSpawner instance = null;
    private static readonly object padlock = new object();

    public static RefactoredObstacleSpawner Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RefactoredObstacleSpawner();
                }
                return instance;
            }
        }
    }

    private RefactoredObstacleSpawner() { }

    [SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;

    protected override void SpawnObject()
    {
        // Implementación para generar un obstáculo
    }
}