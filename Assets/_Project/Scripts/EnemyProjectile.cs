
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float speed = 15f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float lifetime = 5f;

    private Rigidbody rb;
    private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;

        if (target == null || rb == null)
            return;

        Vector3 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DroneHealth droneHealth =
            collision.collider.GetComponentInParent<DroneHealth>();

        if (droneHealth != null)
        {
            droneHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
