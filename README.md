# IDED_Scripting_202310_Parcial3
 
Equipo:
Valentina Roldan
Juan Gabriel Arango
David Marin Yepes

Bugs:
tenemos un problema con la pantalla de GameOver, se enciende una vez y funciona pero por alguna razón se autodestruye y para encenderce por segunda vez no lo hace y genera errores a los demás componentes.

CONTEXTO:
Conviertimos las clases RefactoredGameController, RefactoredPlayerController, RefactoredUIManager y RefactoredObstacleSpawner en Singletons como lo pedia el ejercicio.

La clase tiene una propiedad estática Instance que se utiliza para crear una única instancia de la clase (mediante el patrón Singleton).

RefactoredGameController:El método OnObstacleDestroyed se llama cuando se destruye un obstáculo y, en este caso, notifica a cualquier objeto que esté escuchando los eventos Player_ChangeScore y UI_ChangeScore.El método SetGameOver se llama cuando se establece el estado de juego en GameOver, y en este caso notifica a cualquier objeto que esté escuchando el evento OnGameOverActions.En general, esta clase define la funcionalidad del controlador de juego específico para un juego en particular y proporciona un mecanismo para comunicarse con otros objetos en el juego a través de eventos.

RefactoredPlayerController: En el método Awake(), se comprueba si ya existe una instancia de RefactoredPlayerController y se destruye la nueva si es el caso, para evitar la duplicación de objetos.
En el método Start(), se suscribe a los eventos OnGameOverActions y Player_ChangeScore de la clase RefactoredGameController.
El método Shoot() se encarga de disparar la bala seleccionada por el jugador en la dirección del personaje.
El método SelectBullet() se encarga de seleccionar la bala adecuada de la piscina de balas, según el índice proporcionado. También dispara el evento UI_IconAction para que los objetos interesados puedan actualizar la IU del juego en consecuencia. 
El método OnScoreChangeEvent() está vacío y no tiene funcionalidad porque no supimos para que usarlo.

RefactoredUIManager: En el método Awake(), se comprueba si ya existe una instancia de la clase RefactoredUIManager. Si es así, se destruye la instancia actual para asegurarse de que sólo existe una instancia activa de la clase en todo momento. Si no existe una instancia previa, se establece la instancia actual en esta.
En el método Start(), la clase se suscribe a los eventos UI_ChangeScore y OnGameOverActions definidos en la clase RefactoredGameController, así como al evento UI_IconAction definido en la clase RefactoredPlayerController.
La clase también define un método UpdateScoreLabel() que se utiliza para actualizar la puntuación del jugador en la interfaz de usuario. Además, tiene un método EnableIcon() que se utiliza para habilitar un icono en la interfaz de usuario que indica qué tipo de bala ha seleccionado el jugador. Por último, la clase tiene un método OnGameOver() que se llama cuando el juego termina.

RefactoredObstacleSpawner: El método OnGameOverActions() está ligado al evento RefactoredGameController.OnGameOverActions, lo que significa que cuando se dispare ese evento (porque el jugador ha perdido el juego), el método OnGameOver() se llamará y ejecutará la acción definida en el método base.
El método Awake() comprueba que solo exista una instancia del objeto en la escena y lo asigna a la variable estática Instance para permitir el acceso a la instancia desde otras clases.

PoolBase: PopulatePool(): un método que crea y almacena la cantidad definida de objetos basePrefab en la lista instances. Cada objeto creado se establece en estado inactivo. GetOBJ(): un método que devuelve un objeto de la piscina que se encuentra en estado inactivo, o null si no hay objetos inactivos disponibles. Cuando se devuelve un objeto, se establece en estado activo y se llama al método SetUp() en cualquier componente Ipoolable que el objeto tenga. SetUp() es un método genérico que puede configurar el objeto según sea necesario para su uso.

Se crearon las clases PoolHardBullet, PoolMidBullet y PoolLowBullet: La clase se encarga de manejar un grupo de objetos de tipo "Bullet" para reutilizarlos en vez de crear y destruir nuevos objetos continuamente. El método "Awake()" se llama cuando se inicializa el objeto, y comprueba si ya hay una instancia de "PoolHardBullet" creada. Si ya existe, el objeto actual se destruye y se retorna. De lo contrario, se establece esta instancia como la instancia única. Al heredar de "PoolBase", "PoolHardBullet" también tiene acceso al método "GetOBJ()" que se encarga de buscar y devolver un objeto de la piscina disponible para su uso. La clase también tiene una lista llamada "instances" que contiene los objetos de la piscina y se llena en el método "PopulatePool()" cuando se inicializa el objeto.

Se crearon las clases PoolHardObstacle, PoolMidObstacle y PoolLowObstacle:
crean una instancia única de un pool de objetos de tipo "hard obstacle", "mid obstacle" y "low obstacle" utilizando la clase PoolBase, lo que permite al juego reutilizar objetos y mejorar el rendimiento en tiempo de ejecución.

Ipool: Definimos un método llamado "GetOBJ()" que devuelve un objeto de tipo "GameObject"

Se crearon las clases PoolableOBJ:que implementa la interfaz Ipoolable y proporciona una implementación para sus dos métodos: Recycle() y Ipoolable.SetUp(float i).

El método Recycle() se encarga de "reciclar" el objeto de la piscina. Para hacer esto, establece la velocidad del objeto en cero y desactiva el objeto (llamando al método SetActive(false)). El método Ipoolable.SetUp(float i) establece el tiempo que el objeto estará activo antes de ser reciclado. El método utiliza una coroutine (una función que puede pausarse y reanudarse) para esperar el tiempo especificado antes de llamar al método Recycle().

Base:
GameControllerBase : tiene un método virtual llamado SetGameOver() que se llama cuando el tiempo de juego se acaba. Este método desactiva el componente GameControllerBase. Además, la clase tiene dos métodos privados: Start() y UpdateTime(). Start() se llama una vez cuando el objeto es inicializado y establece RemainingPlayTime en el valor de playTime. UpdateTime() se llama en cada actualización de fotograma y disminuye el tiempo restante de juego. Si RemainingPlayTime llega a cero, llama al método SetGameOver().

UIManagerBase:Esta clase es una clase base abstracta para la gestión de la interfaz de usuario (UI) en un videojuego en Unity. Contiene referencias a elementos de UI como iconos de balas, etiquetas de puntuación y etiquetas de tiempo, así como un panel de fin de juego. También tiene métodos para actualizar la puntuación, habilitar los iconos de las balas y manejar el reinicio del nivel. Además, implementa el método Start y Update, que proporcionan funcionalidad adicional y se pueden sobrescribir en las clases derivadas para personalizar la funcionalidad de la UI en el juego.

PlayerControllerBase:Esta clase es una clase abstracta que define el comportamiento genérico para un controlador de jugador en un juego, que utiliza Unity como motor de juego. Esta clase se encarga de definir los parámetros de movimiento y disparo del jugador, así como también de procesar la entrada del usuario para detectar cuando el jugador debe moverse o disparar. Esta clase también define métodos abstractos que deben ser implementados por las clases que heredan de ella, para seleccionar el tipo de bala a disparar y para realizar el disparo en sí. Además, la clase maneja la puntuación del jugador y la actualización de la misma.




