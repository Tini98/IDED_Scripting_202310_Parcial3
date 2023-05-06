using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    /* [SerializeField]
     private PoolBase obstacleLowPool;

     [SerializeField]
     private PoolBase obstacleMidPool;

     [SerializeField]
     private PoolBase obstacleHardPool;

     protected override void SpawnObject()
     {
         throw new System.NotImplementedException();
     }*/

    [SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;

    public static RefactoredObstacleSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of RefactoredObstacleSpawner");
            Destroy(gameObject);
        }
    }

    
}