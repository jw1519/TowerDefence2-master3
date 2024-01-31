using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Towers : ProjectileObjectPool
{

    public Transform target;
    ProjectileObjectPool objectPooler;

    //public Transform PartToRotate;

    public string enemyTag = "Enemy";


    [Header("Changes")]

    public float range = 100f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public Transform firePoint;
    public GameObject ProjectilePrefab;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        objectPooler = ProjectileObjectPool.instance;
    }
    

    //finding enemy and seeing the distance, targeting system
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // the distance between tower and enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) //if enemy is found within the range
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        ///rotation if needed
        //Vector3 direction = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(direction); //look rotation
        //Vector3 roation = lookRotation.eulerAngles;
        //PartToRotate.rotation = Quaternion.Euler(0f, roation.y, 0f);


        if (target != null)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
        fireCountdown -= Time.deltaTime;
    }
   
    public void Shoot()
    {
        //SpawnFromPool("CannonBall", firePoint.position, Quaternion.identity);

        GameObject projectileGO = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
        projectiles projectiles = projectileGO.GetComponent<projectiles>();
        if (projectiles != null)
        {
            projectiles.Seek(target);
        }
    }

    //creates a radius that is shown when the tower is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
