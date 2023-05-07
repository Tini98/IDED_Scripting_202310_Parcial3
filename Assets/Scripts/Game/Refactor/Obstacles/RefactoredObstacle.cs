using System;
using System.Collections.Generic;

public abstract class RefactoredObstacle : ObstacleBase
{
    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    public static Action<int> OnDestroyAction;

    private void OnEnable()
    {
        RefactoredObstacle.OnDestroyAction += RefactoredGameController.OnObstacleDestroyerdAction;
    }

    private void OnDisable()
    {
        RefactoredObstacle.OnDestroyAction -= RefactoredGameController.OnObstacleDestroyerdAction;
    }

    protected override void DestroyObstacle(bool notify = false)
    {
        if (notify)
        {
            if (OnDestroyAction != null)
            {
                OnDestroyAction(HP);
            }
        }

        if (gameObject.activeSelf && gameObject.activeInHierarchy)
        {
            Ipoolable poolable = GetComponent<Ipoolable>();
            if (poolable != null)
            {
                poolable.Recycle();
            }
        }
    }

}