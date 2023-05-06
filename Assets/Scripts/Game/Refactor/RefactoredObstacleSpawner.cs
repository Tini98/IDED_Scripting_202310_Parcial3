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

    protected override void SpawnObject()
    {
        PoolBase poolToUse = null;

        float randomValue = Random.value;

        if (randomValue < 0.5f)
        {
            poolToUse = obstacleLowPool;
        }
        else if (randomValue < 0.8f)
        {
            poolToUse = obstacleMidPool;
        }
        else
        {
            poolToUse = obstacleHardPool;
        }

        if (poolToUse == null)
        {
            Debug.LogWarning("Obstacle pool is not set");
            return;
        }

        GameObject newObstacle = poolToUse.GetPooledObject();

        if (newObstacle != null)
        {
            float xPos = Random.Range(-6f, 6f);
            float zPos = transform.position.z;

            newObstacle.transform.position = new Vector3(xPos, 0f, zPos);

            newObstacle.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Obstacle pool is empty");
        }
    }
}

