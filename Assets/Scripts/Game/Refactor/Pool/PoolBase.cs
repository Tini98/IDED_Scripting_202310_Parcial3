using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    [SerializeField]
    private int count = 0;

    [SerializeField]
    private GameObject basePrefab;

    public List<GameObject> instances = new List<GameObject>();

    private void Start()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        for (int i = 0; i < count; i++)
        {
            instances.Add(Instantiate(basePrefab, transform.position, Quaternion.identity));
            instances[i].SetActive(false);
        }
    }

    public virtual GameObject GetOBJ()
    {
        for (int i = 0; i < instances.Count; i++)
        {
            if (instances[i] == null) continue; // added null check
            if (!instances[i].activeInHierarchy)
            {
                instances[i].SetActive(true);
                Ipoolable poolable = instances[i].GetComponent<Ipoolable>();
                if (poolable != null)
                {
                    poolable.SetUp(2);
                }
                return instances[i];
            }
        }
        return null;
    }
}