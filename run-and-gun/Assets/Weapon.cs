using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    float fireRate = 0.55f;
    float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("IsShooting") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            SoundManagerScript.PlaySound("shot");
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
