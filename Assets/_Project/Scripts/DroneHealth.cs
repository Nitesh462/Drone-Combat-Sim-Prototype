using UnityEngine;

public class DroneHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Drone Health: " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);

        Debug.Log("Drone Health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Debug.Log("Drone destroyed!");

            DroneController controller = GetComponent<DroneController>();
            if (controller != null)
                controller.enabled = false;

            DroneMissileLauncher launcher =
                GetComponent<DroneMissileLauncher>();
            if (launcher != null)
                launcher.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
