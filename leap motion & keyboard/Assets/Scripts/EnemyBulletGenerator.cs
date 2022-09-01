using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGenerator : MonoBehaviour
{
    private void shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        bullet.GetComponent<BulletController>().Shoot(new Vector3(0, 0, -400));
    }
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shooting", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}