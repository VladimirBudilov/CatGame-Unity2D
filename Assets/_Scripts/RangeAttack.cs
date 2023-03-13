using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float bulletSpeed;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Attack();
    }
    private void Attack()
    {
        var bullet = Instantiate(bulletPref, gun.position, gun.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(gun.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
