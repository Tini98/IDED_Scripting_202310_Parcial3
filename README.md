# IDED_Scripting_202310_Parcial3
 
Equipo:
Valentina Roldan
Juan Gabriel Arango
David Marin Yepes

Bugs:
tenemos un problema con la pantalla de GameOver, se enciende una vez y funciona pero por alguna raz�n se autodestruye y para encenderce por segunda vez no lo hace y genera errores a los dem�s componentes.

CONTEXTO:
Conviertimos las clases RefactoredGameController, RefactoredPlayerController, RefactoredUIManager y RefactoredObstacleSpawner en Singletons como lo pedia el ejercicio.

La clase tiene una propiedad est�tica Instance que se utiliza para crear una �nica instancia de la clase (mediante el patr�n Singleton).

RefactoredGameController:El m�todo OnObstacleDestroyed se llama cuando se destruye un obst�culo y, en este caso, notifica a cualquier objeto que est� escuchando los eventos Player_ChangeScore y UI_ChangeScore.El m�todo SetGameOver se llama cuando se establece el estado de juego en GameOver, y en este caso notifica a cualquier objeto que est� escuchando el evento OnGameOverActions.En general, esta clase define la funcionalidad del controlador de juego espec�fico para un juego en particular y proporciona un mecanismo para comunicarse con otros objetos en el juego a trav�s de eventos.

RefactoredPlayerController: En el m�todo Awake(), se comprueba si ya existe una instancia de RefactoredPlayerController y se destruye la nueva si es el caso, para evitar la duplicaci�n de objetos.
En el m�todo Start(), se suscribe a los eventos OnGameOverActions y Player_ChangeScore de la clase RefactoredGameController.
El m�todo Shoot() se encarga de disparar la bala seleccionada por el jugador en la direcci�n del personaje.
El m�todo SelectBullet() se encarga de seleccionar la bala adecuada de la piscina de balas, seg�n el �ndice proporcionado. Tambi�n dispara el evento UI_IconAction para que los objetos interesados puedan actualizar la IU del juego en consecuencia. 
El m�todo OnScoreChangeEvent() est� vac�o y no tiene funcionalidad porque no supimos para que usarlo.

RefactoredUIManager: En el m�todo Awake(), se comprueba si ya existe una instancia de la clase RefactoredUIManager. Si es as�, se destruye la instancia actual para asegurarse de que s�lo existe una instancia activa de la clase en todo momento. Si no existe una instancia previa, se establece la instancia actual en esta.
En el m�todo Start(), la clase se suscribe a los eventos UI_ChangeScore y OnGameOverActions definidos en la clase RefactoredGameController, as� como al evento UI_IconAction definido en la clase RefactoredPlayerController.
La clase tambi�n define un m�todo UpdateScoreLabel() que se utiliza para actualizar la puntuaci�n del jugador en la interfaz de usuario. Adem�s, tiene un m�todo EnableIcon() que se utiliza para habilitar un icono en la interfaz de usuario que indica qu� tipo de bala ha seleccionado el jugador. Por �ltimo, la clase tiene un m�todo OnGameOver() que se llama cuando el juego termina.

RefactoredObstacleSpawner: El m�todo OnGameOverActions() est� ligado al evento RefactoredGameController.OnGameOverActions, lo que significa que cuando se dispare ese evento (porque el jugador ha perdido el juego), el m�todo OnGameOver() se llamar� y ejecutar� la acci�n definida en el m�todo base.
El m�todo Awake() comprueba que solo exista una instancia del objeto en la escena y lo asigna a la variable est�tica Instance para permitir el acceso a la instancia desde otras clases.

PoolBase: PopulatePool(): un m�todo que crea y almacena la cantidad definida de objetos basePrefab en la lista instances. Cada objeto creado se establece en estado inactivo. GetOBJ(): un m�todo que devuelve un objeto de la piscina que se encuentra en estado inactivo, o null si no hay objetos inactivos disponibles. Cuando se devuelve un objeto, se establece en estado activo y se llama al m�todo SetUp() en cualquier componente Ipoolable que el objeto tenga. SetUp() es un m�todo gen�rico que puede configurar el objeto seg�n sea necesario para su uso.

Se crearon las clases PoolHardBullet, PoolMidBullet y PoolLowBullet: La clase se encarga de manejar un grupo de objetos de tipo "Bullet" para reutilizarlos en vez de crear y destruir nuevos objetos continuamente. El m�todo "Awake()" se llama cuando se inicializa el objeto, y comprueba si ya hay una instancia de "PoolHardBullet" creada. Si ya existe, el objeto actual se destruye y se retorna. De lo contrario, se establece esta instancia como la instancia �nica. Al heredar de "PoolBase", "PoolHardBullet" tambi�n tiene acceso al m�todo "GetOBJ()" que se encarga de buscar y devolver un objeto de la piscina disponible para su uso. La clase tambi�n tiene una lista llamada "instances" que contiene los objetos de la piscina y se llena en el m�todo "PopulatePool()" cuando se inicializa el objeto.

Se crearon las clases PoolHardObstacle, PoolMidObstacle y PoolLowObstacle:
crean una instancia �nica de un pool de objetos de tipo "hard obstacle", "mid obstacle" y "low obstacle" utilizando la clase PoolBase, lo que permite al juego reutilizar objetos y mejorar el rendimiento en tiempo de ejecuci�n.

Ipool: Definimos un m�todo llamado "GetOBJ()" que devuelve un objeto de tipo "GameObject"

Se crearon las clases PoolableOBJ:que implementa la interfaz Ipoolable y proporciona una implementaci�n para sus dos m�todos: Recycle() y Ipoolable.SetUp(float i).

El m�todo Recycle() se encarga de "reciclar" el objeto de la piscina. Para hacer esto, establece la velocidad del objeto en cero y desactiva el objeto (llamando al m�todo SetActive(false)). El m�todo Ipoolable.SetUp(float i) establece el tiempo que el objeto estar� activo antes de ser reciclado. El m�todo utiliza una coroutine (una funci�n que puede pausarse y reanudarse) para esperar el tiempo especificado antes de llamar al m�todo Recycle().

Base:
GameControllerBase : tiene un m�todo virtual llamado SetGameOver() que se llama cuando el tiempo de juego se acaba. Este m�todo desactiva el componente GameControllerBase. Adem�s, la clase tiene dos m�todos privados: Start() y UpdateTime(). Start() se llama una vez cuando el objeto es inicializado y establece RemainingPlayTime en el valor de playTime. UpdateTime() se llama en cada actualizaci�n de fotograma y disminuye el tiempo restante de juego. Si RemainingPlayTime llega a cero, llama al m�todo SetGameOver().

UIManagerBase:Esta clase es una clase base abstracta para la gesti�n de la interfaz de usuario (UI) en un videojuego en Unity. Contiene referencias a elementos de UI como iconos de balas, etiquetas de puntuaci�n y etiquetas de tiempo, as� como un panel de fin de juego. Tambi�n tiene m�todos para actualizar la puntuaci�n, habilitar los iconos de las balas y manejar el reinicio del nivel. Adem�s, implementa el m�todo Start y Update, que proporcionan funcionalidad adicional y se pueden sobrescribir en las clases derivadas para personalizar la funcionalidad de la UI en el juego.

PlayerControllerBase:Esta clase es una clase abstracta que define el comportamiento gen�rico para un controlador de jugador en un juego, que utiliza Unity como motor de juego. Esta clase se encarga de definir los par�metros de movimiento y disparo del jugador, as� como tambi�n de procesar la entrada del usuario para detectar cuando el jugador debe moverse o disparar. Esta clase tambi�n define m�todos abstractos que deben ser implementados por las clases que heredan de ella, para seleccionar el tipo de bala a disparar y para realizar el disparo en s�. Adem�s, la clase maneja la puntuaci�n del jugador y la actualizaci�n de la misma.




