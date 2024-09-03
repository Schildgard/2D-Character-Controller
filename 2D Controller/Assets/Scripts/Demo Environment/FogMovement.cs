using UnityEngine;

public class FogMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed *Time.deltaTime, transform.position.y, transform.position.z);
    }
}
