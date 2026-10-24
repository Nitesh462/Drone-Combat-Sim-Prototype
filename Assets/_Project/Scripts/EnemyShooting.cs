
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 2f;

    private EnemyDetection enemyDetection;
    private float fireTimer;

    private void Start()
    {
        enemyDetection = GetComponent<EnemyDetection>();
    }

    private void Update()
    {
        if (enemyDetection == null ||
            !enemyDetection.TargetDetected ||
            enemyDetection.Target == null)
        {
            fireTimer = 0f;
            return;
        }

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
            return;

        Transform target = enemyDetection.Target;

        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        EnemyProjectile projectileScript =
            projectile.GetComponent<EnemyProjectile>();

        if (projectileScript != null)
        {
            projectileScript.SetTarget(target);
        }
    }
}
