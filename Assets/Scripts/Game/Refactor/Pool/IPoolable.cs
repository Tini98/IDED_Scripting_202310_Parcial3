using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPoolable // Solo definimos la interfaz llamada "IPoolable"
{
    // Método que configura el comportamiento del objeto en la pool
    public void SetUp(float i);

    // Método que devuelve el objeto a la pool
    public void Recycle();
}
