public class RefactoredUIManager : UIManagerBase
{
    /* protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

     protected override GameControllerBase GameController => throw new System.NotImplementedException();*/


    private static RefactoredUIManager instance = null;
    private static readonly object padlock = new object();

    public static RefactoredUIManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RefactoredUIManager();
                }
                return instance;
            }
        }
    }

    private RefactoredUIManager() { }

    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;
    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    public void ShowGameOverScreen()
    {
        // Implementación para mostrar la pantalla de Game Over
    }
}