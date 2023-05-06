using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BulletPool : MonoBehaviour
{
    private static BulletPool instance;
    public static BulletPool Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private Rigidbody bullet;

    public static Rigidbody Bullet
    {
        get
        {
            return instance.bullet;
        }
    }

    [SerializeField]
    private Rigidbody bullet2;

    public static Rigidbody Bullet2
    {
        get
        {
            return instance.bullet2;
        }
    }
    [SerializeField]
    private Rigidbody bullet3;

    public static Rigidbody Bullet3
    {
        get
        {
            return instance.bullet3;
        }
    }
    [SerializeField]
    private int Size;
    private List<Rigidbody> bullets;
    private List<Rigidbody> bullets2;
    private List<Rigidbody> bullets3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PrepareBullets();
        }
        else

            Destroy(gameObject);

    }
    private void PrepareBullets()
    {
        bullets = new List<Rigidbody>();
        for (int i = 0; i < Size; i++)
            AddBullet();

    }
    public Rigidbody GetBullet()
    {
        if (bullets.Count == 0)
            AddBullet();

        return AllocateBullet();
    }
    public void ReleaseBullet(Rigidbody bullet)
    {
        bullet.gameObject.SetActive(false);
        bullets.Add(bullet);
    }
    private void AddBullet()
    {
        Rigidbody instance = Instantiate(bullet);
        instance.gameObject.SetActive(false);
        bullets.Add(instance);
    }

    private Rigidbody AllocateBullet()
    {
        Rigidbody bullet = bullets[bullets.Count - 1];
        bullets.RemoveAt(bullets.Count - 1);
        bullet.gameObject.SetActive(true);
        return bullet;
    }
}
