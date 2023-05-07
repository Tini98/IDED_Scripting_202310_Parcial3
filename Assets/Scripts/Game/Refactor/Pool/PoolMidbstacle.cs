using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hereda de "PoolBase"
public class PoolMidbstacle : PoolBase
{
    // Propiedad estática que representa una única instancia de la clase "PoolMidbstacle"
    public static PoolMidbstacle Instance { get; private set; } = null;

    // Método que se ejecuta cuando se inicializa el objeto
    private void Awake()
    {
        // Si ya hay una instancia de "PoolMidbstacle", destruye este objeto y retorna
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        // Si no hay una instancia de "PoolMidbstacle", establece esta instancia como la instancia única
        Instance = this;
    }
}