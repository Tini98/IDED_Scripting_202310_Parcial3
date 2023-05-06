using UnityEngine;

public sealed class RefactoredGameController : GameControllerBase
{
    /*protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    protected override UIManagerBase UiManager => throw new System.NotImplementedException();

    protected override ObstacleSpawnerBase Spawner => throw new System.NotImplementedException();

    protected override void OnObstacleDestroyed(int hp)
    {
        throw new System.NotImplementedException();
    }*/

    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;

    protected override UIManagerBase UiManager => RefactoredUIManager.Instance;

    protected override ObstacleSpawnerBase Spawner => RefactoredObstacleSpawner.Instance;

    public static RefactoredGameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of RefactoredGameController");
            Destroy(gameObject);
        }
    }

    protected override void OnObstacleDestroyed(int hp)
    {
        // Aquí puedes agregar el código que se ejecutará cuando se destruya un obstáculo
    }
}