using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    [SerializeField]
    private int count = 0;

    [SerializeField]
    private GameObject basePrefab;

    private List<GameObject> instances = new List<GameObject>();

    public void RecycleInstance(GameObject instance)
    {
        throw new System.NotImplementedException();
    }

    public GameObject RetrieveInstance()
    {
        throw new System.NotImplementedException();
    }

    private void PopulatePool()
    {
        for (int i = 0; i < count; i++)
        {
            instances.Add(Instantiate(basePrefab, transform.position, Quaternion.identity));
        }
    }
    public GameObject GetPooledObject()
    {
        foreach (GameObject instance in instances)
        {
            if (!instance.activeInHierarchy)
            {
                return instance;
            }
        }

        return null;
    }
}