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

    protected override bool NoSelectedBullet => false;

    public static RefactoredPlayerController Instance { get; private set; }

    private void Awake()
    {
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
        // Aqu� puedes agregar el c�digo que se ejecutar� cuando se dispare un proyectil
    }

    protected override void SelectBullet(int index)
    {
        // Aqu� puedes agregar el c�digo que se ejecutar� cuando se seleccione un proyectil
    }

}