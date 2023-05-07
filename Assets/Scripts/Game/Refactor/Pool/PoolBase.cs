using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    // Atributo privado que indica la cantidad de objetos que se instanciarán en la pool
    [SerializeField]
    private int count = 0;

    // Atributo privado que almacena el prefab que se instanciará para crear los objetos de la pool
    [SerializeField]
    private GameObject basePrefab;

    // Lista que almacena las instancias creadas
    public List<GameObject> instances = new List<GameObject>();

    // Método Start que se ejecuta al inicio del juego
    private void Start()
    {
        // Llama al método "PopulatePool()" para crear las instancias de la pool
        PopulatePool();
    }

    // Método que crea las instancias de la pool
    private void PopulatePool()
    {
        // Ciclo for que crea "count" instancias de "basePrefab" y las agrega a la lista "instances"
        for (int i = 0; i < count; i++)
        {
            instances.Add(Instantiate(basePrefab, transform.position, Quaternion.identity));
            instances[i].SetActive(false);
        }
    }

    // Método virtual que debe ser implementado por las clases que hereden de "PoolBase"
    // Devuelve un GameObject de la pool que se encuentre inactivo
    public virtual GameObject GetOBJ()
    {
        // Ciclo for que recorre la lista "instances" en busca de un objeto inactivo
        for (int i = 0; i < instances.Count; i++)
        {
            if (!instances[i].activeInHierarchy)
            {
                // Si encuentra un objeto inactivo, lo activa, configura su comportamiento a través del método "SetUp()" y lo devuelve
                instances[i].SetActive(true);
                instances[i].GetComponent<Ipoolable>().SetUp(2);
                return instances[i];
            }
        }
        // Si no encuentra ningún objeto inactivo, devuelve "null"
        return null;
    }
}