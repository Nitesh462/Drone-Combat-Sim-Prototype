using UnityEngine;

public class DroneMissileLauncher : MonoBehaviour
{
    [Header("Missile Settings")]
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform missileSpawnPoint;
    [SerializeField] private float missileSpeed = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FireMissile();
    }

    private void FireMissile()
    {
        GameObject missile = Instantiate(
            missilePrefab,
            missileSpawnPoint.position,
            missileSpawnPoint.rotation);

        Rigidbody missileRb = missile.GetComponent<Rigidbody>();

        missileRb.linearVelocity = missileSpawnPoint.forward * missileSpeed;
    }
}
