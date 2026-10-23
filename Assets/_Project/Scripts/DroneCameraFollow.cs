using UnityEngine;

public class DroneCameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Camera Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0f,5f,-9f);
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float lookSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime);

        Quaternion desiredRotation = Quaternion.LookRotation(
            target.position - transform.position
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation,
            lookSpeed * Time.deltaTime);
    }

}
