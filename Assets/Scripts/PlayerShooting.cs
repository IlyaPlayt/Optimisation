using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    bool shouldExpand;
    public bool spreadShot = false;

    [Header("General")] public Transform gunBarrel;
    public ParticleSystem shotVFX;
    public AudioSource shotAudio;
    public float fireRate = .1f;
    public int spreadAmount = 20;

    [Header("Bullets")] public GameObject bulletPrefab;

    float timer;

    private List<GameObject> _bulletsPool;

   [SerializeField] private int _bulletAmount;

    void Start()
    {
        shouldExpand = true;
        _bulletsPool = new List<GameObject>();
        CrateBulletPool(_bulletAmount);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= fireRate)
        {
            Vector3 rotation = gunBarrel.rotation.eulerAngles;
            rotation.x = 0f;

            if (spreadShot)
                SpawnBulletSpread(rotation);
            else
                SpawnBullet(rotation);


            timer = 0f;

            if (shotVFX)
                shotVFX.Play();

            if (shotAudio)
                shotAudio.Play();
        }
    }

    void SpawnBullet(Vector3 rotation)
    {
        Debug.Log("Bullet");
        GameObject bullet = GetBulletFromPool();
        bullet.transform.position = gunBarrel.position;
        bullet.transform.rotation = Quaternion.Euler(rotation);
        bullet.SetActive(true);
    }

    void SpawnBulletSpread(Vector3 rotation)
    {
        int max = spreadAmount / 2;
        int min = -max;

        Vector3 tempRot = rotation;
        for (int x = min; x < max; x++)
        {
            tempRot.x = (rotation.x + 3 * x) % 360;

            for (int y = min; y < max; y++)
            {
                tempRot.y = (rotation.y + 3 * y) % 360;

                GameObject bullet = GetBulletFromPool();

                bullet.transform.position = gunBarrel.position;
                bullet.transform.rotation = Quaternion.Euler(tempRot);
                bullet.SetActive(true);
            }
        }
    }

    private void CrateBulletPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateNewBullet();
        }
    }

    private GameObject GetBulletFromPool()
    {
        foreach (var bullet in _bulletsPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        if (shouldExpand)
        {
            return CreateNewBullet();
        }

        return null;
    }

    private GameObject CreateNewBullet()
    {
        GameObject obj = (GameObject) Instantiate(bulletPrefab);
        obj.SetActive(false);
        //obj.transform.parent = this.transform;
        _bulletsPool.Add(obj);
        return obj;
    }
}