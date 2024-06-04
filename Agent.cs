using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpawnDistance = 1f; // Distance in front of the bulletSpawnPoint to instantiate the bullet
    public float shootingInterval = 2f;
    public float bulletSpeed = 50f;
    public float detectionRange = 50f;
    private float shootingTimer;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootingTimer = shootingInterval;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            AimAtPlayer();
            shootingTimer -= Time.deltaTime;

            if (shootingTimer <= 0f)
            {
                Shoot();
                shootingTimer = shootingInterval;
            }
        }
    }

    void AimAtPlayer()
    {
        transform.LookAt(player);
        bulletSpawnPoint.LookAt(player);  // Make sure the bulletSpawnPoint is aimed at the player
    }

    void Shoot()
    {
        Debug.Log("Shooting");
        Debug.Log("Bullet speed: " + bulletSpeed);

        // Calculate the position to spawn the bullet
        Vector3 spawnPosition = bulletSpawnPoint.position + bulletSpawnPoint.forward * bulletSpawnDistance;
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        // Calculate the direction towards the player
        Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
        rb.velocity = directionToPlayer * bulletSpeed;
    }
}
