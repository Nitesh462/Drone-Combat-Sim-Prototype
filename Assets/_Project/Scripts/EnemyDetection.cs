using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Target Setting")]
    [SerializeField] private string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            Debug.Log("Drone Detected!", this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
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
        
    }
}
