using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool3 : PoolBase
{
    [SerializeField]
    private GameObject bulletLow;

    private Queue<GameObject> inactiveBullets = new Queue<GameObject>();

    public GameObject RetrieveInstance()
    {
        GameObject bullet;

        if (inactiveBullets.Count > 0)
        {
            bullet = inactiveBullets.Dequeue();
        }
        else
        {
            bullet = Instantiate(bulletLow);
        }

        bullet.SetActive(true);

        return bullet;
    }

    public void RecycleInstance(GameObject bullet)
    {
        bullet.SetActive(false);
        inactiveBullets.Enqueue(bullet);
    }
}
