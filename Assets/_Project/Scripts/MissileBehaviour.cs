using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f;

    [SerializeField] private GameObject explosionPrefab;

    private bool hasExploded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasExploded)
            return;

        if(collision.gameObject.CompareTag("Target"))
        {
            hasExploded=true;

            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
