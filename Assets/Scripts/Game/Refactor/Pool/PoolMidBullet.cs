using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Definimos una clase llamada "PoolMidBullet" que hereda de "PoolBase"
public class PoolMidBullet : PoolBase
{
    // Define una propiedad est�tica que representa una �nica instancia de la clase "PoolMidBullet"
    public static PoolMidBullet Instance { get; private set; } = null;

    // M�todo que se ejecuta cuando se inicializa el objeto
    private void Awake()
    {
        // Si ya hay una instancia de "PoolMidBullet", destruye este objeto y retorna
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        // Si no hay una instancia de "PoolMidBullet", establece esta instancia como la instancia �nica
        Instance = this;
    }
}
