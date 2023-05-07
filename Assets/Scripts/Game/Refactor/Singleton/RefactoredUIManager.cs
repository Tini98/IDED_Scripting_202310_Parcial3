public class RefactoredUIManager : UIManagerBase
{
    public static RefactoredUIManager Instance { get; private set; } = null;

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

        RefactoredGameController.UI_ChangeScore += UpdateScoreLabel;
        RefactoredGameController.OnGameOverActions += OnGameOver;
        RefactoredPlayerController.UI_IconAction += EnableIcon;
    }

    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;

    protected override GameControllerBase GameController => RefactoredGameController.Instance;
} 
