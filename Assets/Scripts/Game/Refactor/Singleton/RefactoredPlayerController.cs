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

    /*private static RefactoredPlayerController instance = null;
    private static readonly object padlock = new object();

    public static RefactoredPlayerController Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RefactoredPlayerController();
                }
                return instance;
            }
        }
    }

    private RefactoredPlayerController() { }

    protected override bool NoSelectedBullet => throw new System.NotImplementedException();
    protected override void Shoot() { }
    protected override void SelectBullet(int index) { }*/

    private bool noSelectedBullet = true;
    private int selectedBulletIndex = -1;

    private static RefactoredPlayerController instance = null;
    private static readonly object padlock = new object();

    public static RefactoredPlayerController Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RefactoredPlayerController();
                }
                return instance;
            }
        }
    }

    private RefactoredPlayerController() { }

    protected override bool NoSelectedBullet => noSelectedBullet;

    protected override void Shoot()
    {
        // Implementación de ejecutar cuando se dispara una bala
    }

    protected override void SelectBullet(int index)
    {
        selectedBulletIndex = index;
        noSelectedBullet = false;
    }
}