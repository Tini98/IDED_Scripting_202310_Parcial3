# IDED_Scripting_202310_Parcial3
 Members:
Valentina Rold�n Restrepo
Juan Gabriel Arango
David Marin Yepes

Changes made:

Convierta las clases RefactoredGameController, RefactoredPlayerController, RefactoredUIManager y RefactoredObstacleSpawner en Singletons (0.43).
para este punto:
RefactoredGameController: este script se define que la clase RefactoredGameController que hereda de la clase abstracta GameControllerBase. Hicimos una nueva implementaci�n, creado un patr�n singleton para garantizar que solo haya una instancia de esta clase en la ejecuci�n del juego. Declaramos una instancia privada y est�tica del singleton y un objeto padlock para controlar el acceso. Se define un getter p�blico para la instancia del singleton que utiliza el patr�n "lazy initialization" para crear la instancia solo cuando es necesaria.

El constructor de la clase se declara como privado para evitar la creaci�n de instancias fuera de la clase. Adem�s, implementamos los m�todos abstractos de la clase base PlayerController, UiManager y Spawner. Por �ltimo, implementamos el m�todo OnObstacleDestroyed que se ejecuta cuando un obst�culo es destruido en el juego.


RefactoredPlayerController: se hizo implementaci�n de la clase RefactoredPlayerController para hacerla un Singleton como se pide, nos aseguramos que solo se pueda haber una instancia de esta clase en el juego. Adem�s, se eliminaron los m�todos comentados que no estaban siendo utilizados. Tambi�n agregamos un par de variables de instancia "noSelectedBullet" y "selectedBulletIndex" para llevar un registro de la bala seleccionada por el jugador e implemente los m�todos "Shoot" y "SelectBullet" para manejar el disparo de balas y la selecci�n de una bala por parte del jugador. 


RefactoredUIManager: se hizo implementaci�n de la clase RefactoredUIManager en un Singleton mediante el patr�n de dise�o Singleton, lo que nos asegura que solo exista una �nica instancia de la clase en el programa. Implementamos los m�todos abstractos de la clase UIManagerBase, PlayerController y GameController, mediante el uso de las instancias Singleton de RefactoredPlayerController y RefactoredGameController, respectivamente. Agregamos un nuevo m�todo p�blico ShowGameOverScreen, que contiene la implementaci�n para mostrar la pantalla de Game Over en la interfaz de usuario.


RefactoredObstacleSpawner: se hizo implementaci�n de la clase RefactoredObstacleSpawner en un singleton utilizando el patr�n de dise�o Singleton. Tambi�n agragamos referencias serializadas a los objetos tipo Pool:  obstacleLowPool, obstacleMidPool y obstacleHardPool. La funci�n SpawnObject() tambi�n fue implementada con una l�gica para generar un obst�culo en el juego.