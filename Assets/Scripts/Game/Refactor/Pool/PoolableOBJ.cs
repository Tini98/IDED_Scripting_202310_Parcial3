using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableOBJ : MonoBehaviour, Ipoolable
{
    public void Recycle()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    void Ipoolable.SetUp(float i)
    {
        StartCoroutine(DeactivateOBJ(i));
    }

    private IEnumerator DeactivateOBJ(float i)
    {
        yield return new WaitForSeconds(i);
        Recycle();
    }
}
