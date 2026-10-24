using UnityEngine;

public class DroneController : MonoBehaviour
{
    // Movement
    private float moveSpeed = 8f;
    private float verticalSpeed = 5f;

    // Rotation
    private float rotationSpeed = 5f;
    private float maxTiltAngle = 20f;


    private float horizontalInput;
    private float forwardInput;
    private float verticalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        MoveDrone();
        TiltDrone();
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");

        verticalInput = 0f;

        if (Input.GetKey(KeyCode.E))
            verticalInput += 1f;

        if (Input.GetKey(KeyCode.Q))
            verticalInput -= 1f;
    }

    private void MoveDrone()
    {
        Vector3 movement = new Vector3(
            horizontalInput,
            verticalInput * verticalSpeed/moveSpeed,
            forwardInput);

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    private void TiltDrone()
    {
        float targetPitch = forwardInput * maxTiltAngle;
        float targetRoll = -horizontalInput * maxTiltAngle;

        Quaternion targetRotation = Quaternion.Euler(
            targetPitch,
            0f,
            targetRoll);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }
}
