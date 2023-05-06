public sealed class RefactoredGameController : GameControllerBase
{
    /*protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    protected override UIManagerBase UiManager => throw new System.NotImplementedException();

    protected override ObstacleSpawnerBase Spawner => throw new System.NotImplementedException();

    protected override void OnObstacleDestroyed(int hp)
    {
        throw new System.NotImplementedException();
    }*/


    // Se declara una instancia privada y estática del singleton
    private static RefactoredGameController instance = null;

    // Se declara un objeto para controlar el acceso concurrente al singleton
    private static readonly object padlock = new object();

    // Se define un getter público para la instancia del singleton
    public static RefactoredGameController Instance
    {
        get
        {
            // Se utiliza el diseño "lazy initialization" para crear la instancia solo cuando es necesaria
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RefactoredGameController();
                }
                return instance;
            }
        }
    }

    // Se declara el constructor privado para evitar la creación de instancias fuera de la clase
    private RefactoredGameController() { }

    // Implementa los métodos abstractos de la clase base
    protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();
    protected override UIManagerBase UiManager => throw new System.NotImplementedException();
    protected override ObstacleSpawnerBase Spawner => throw new System.NotImplementedException();

    // Implementa el método OnObstacleDestroyed de la clase base
    protected override void OnObstacleDestroyed(int hp)
    {
        // Implementación de ejecutar cuando un obstáculo es destruido
    }
}