using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float rotationSpeed = 100f; // Tốc độ quay

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
