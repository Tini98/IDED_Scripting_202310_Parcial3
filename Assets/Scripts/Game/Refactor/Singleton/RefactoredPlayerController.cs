using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    /*protected override bool NoSelectedBullet => throw new System.NotImplementedException();

     protected override void Shoot()
     {
         //base.Shoot();
     }

     protected override void SelectBullet(int index)
     {
         //base.SelectBullet(index);
     }*/

    //[SerializeField]
    //public BulletPool1 bulletHard;

    [SerializeField]
    public BulletPool2 bulletMid;

    [SerializeField]
    public BulletPool3 bulletLow;

    

    protected override bool NoSelectedBullet => SelectedBulletIndex < 0;

    public static RefactoredPlayerController Instance { get; private set; }

    private void Awake()
    {
        bulletHard = new BulletPool1();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of RefactoredPlayerController");
            Destroy(gameObject);
        }
    }

    protected override void Shoot()
    {
        GameObject bullet = null;

        switch (SelectedBulletIndex)
        {
            case 0:
                bullet = bulletHard.RetrieveInstance();
                break;
            case 1:
                bullet = bulletMid.RetrieveInstance();
                break;
            case 2:
                bullet = bulletLow.RetrieveInstance();
                break;
        }

        switch (SelectedBulletIndex)
        {
            case 0:
                bulletHard.RecycleInstance(bullet);
                break;
            case 1:
                bulletMid.RecycleInstance(bullet);
                break;
            case 2:
                bulletLow.RecycleInstance(bullet);
                break;
        }
    }

    protected override void SelectBullet(int index)
    {
        SelectedBulletIndex = index;
    }
}