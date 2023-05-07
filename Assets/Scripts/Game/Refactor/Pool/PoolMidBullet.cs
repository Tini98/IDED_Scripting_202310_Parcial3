// Definimos una clase llamada "PoolMidBullet" que hereda de "PoolBase"
public class PoolMidBullet : PoolBase
{
    // Define una propiedad estática que representa una única instancia de la clase "PoolMidBullet"
    public static PoolMidBullet Instance { get; private set; } = null;

    // Método que se ejecuta cuando se inicializa el objeto
    private void Awake()
    {
        // Si ya hay una instancia de "PoolMidBullet", destruye este objeto y retorna
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        // Si no hay una instancia de "PoolMidBullet", establece esta instancia como la instancia única
        Instance = this;
    }
}
