using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;


    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }


    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
