using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Target Setting")]
    [SerializeField] private string targetTag = "Player";

    [Header("Aiming Setting")]
    [SerializeField] private float rotationSpeed = 5f;

    private Transform target;
    private bool targetDetected;

    // so other files can read these values
    public bool TargetDetected => targetDetected;
    public Transform Target => target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            target = other.transform;
            targetDetected = true;

            Debug.Log("Drone Detected!", this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            target = null;
            targetDetected = false;

            Debug.Log("Drone Lost!", this);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDetected || target == null)
            return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }
}
