using System;
using System.Collections.Generic;
using System.Diagnostics;

public sealed class RefactoredGameController : GameControllerBase
{
    public static RefactoredGameController Instance { get; private set; } = null;

    public static event Action<int> Player_ChangeScore;
    public static event Action UI_ChangeScore;
    public static event Action OnGameOverActions;
    public static Action<int> OnObstacleDestroyerdAction;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        OnObstacleDestroyerdAction = OnObstacleDestroyed;
    }

    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;

    protected override UIManagerBase UiManager => RefactoredUIManager.Instance;

    protected override ObstacleSpawnerBase Spawner => RefactoredObstacleSpawner.Instance;

    protected override void OnObstacleDestroyed(int hp)
    {
        if (Player_ChangeScore != null)
            Player_ChangeScore(hp);
        if (UI_ChangeScore != null)
            UI_ChangeScore();
    }

    protected override void SetGameOver()
    {
        if (OnGameOverActions != null)
            OnGameOverActions();
        base.SetGameOver();
    }

}