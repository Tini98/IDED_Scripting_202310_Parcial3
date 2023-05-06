# IDED_Scripting_202310_Parcial3
 Members:
Valentina Roldán Restrepo
Juan Gabriel Arango
David Marin Yepes

Changes made:

Convierta las clases RefactoredGameController, RefactoredPlayerController, RefactoredUIManager y RefactoredObstacleSpawner en Singletons (0.43).
para este punto:
RefactoredGameController: este script se define que la clase RefactoredGameController que hereda de la clase abstracta GameControllerBase. Hicimos una nueva implementación, creado un patrón singleton para garantizar que solo haya una instancia de esta clase en la ejecución del juego. Declaramos una instancia privada y estática del singleton y un objeto padlock para controlar el acceso. Se define un getter público para la instancia del singleton que utiliza el patrón "lazy initialization" para crear la instancia solo cuando es necesaria.

El constructor de la clase se declara como privado para evitar la creación de instancias fuera de la clase. Además, implementamos los métodos abstractos de la clase base PlayerController, UiManager y Spawner. Por último, implementamos el método OnObstacleDestroyed que se ejecuta cuando un obstáculo es destruido en el juego.


RefactoredPlayerController: se hizo implementación de la clase RefactoredPlayerController para hacerla un Singleton como se pide, nos aseguramos que solo se pueda haber una instancia de esta clase en el juego. Además, se eliminaron los métodos comentados que no estaban siendo utilizados. También agregamos un par de variables de instancia "noSelectedBullet" y "selectedBulletIndex" para llevar un registro de la bala seleccionada por el jugador e implemente los métodos "Shoot" y "SelectBullet" para manejar el disparo de balas y la selección de una bala por parte del jugador. 


RefactoredUIManager: se hizo implementación de la clase RefactoredUIManager en un Singleton mediante el patrón de diseño Singleton, lo que nos asegura que solo exista una única instancia de la clase en el programa. Implementamos los métodos abstractos de la clase UIManagerBase, PlayerController y GameController, mediante el uso de las instancias Singleton de RefactoredPlayerController y RefactoredGameController, respectivamente. Agregamos un nuevo método público ShowGameOverScreen, que contiene la implementación para mostrar la pantalla de Game Over en la interfaz de usuario.


RefactoredObstacleSpawner: se hizo implementación de la clase RefactoredObstacleSpawner en un singleton utilizando el patrón de diseño Singleton. También agragamos referencias serializadas a los objetos tipo Pool:  obstacleLowPool, obstacleMidPool y obstacleHardPool. La función SpawnObject() también fue implementada con una lógica para generar un obstáculo en el juego.