using UnityEngine;

public class RefactoredUIManager : UIManagerBase
{
    /* protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

     protected override GameControllerBase GameController => throw new System.NotImplementedException();
*/
    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;

    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    public static RefactoredUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of RefactoredUIManager");
            Destroy(gameObject);
        }
    }

}