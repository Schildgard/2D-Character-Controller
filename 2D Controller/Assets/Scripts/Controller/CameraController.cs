using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camera follows the Player and when pressed Up or Down, scrolls down a bit
    private float verticalInput;
    private const float cameraDistance = -10;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float maxCameraDisplacement;

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.position = Vector3.Lerp(playerTransform.position, new Vector3(playerTransform.position.x, playerTransform.position.y + (verticalInput * maxCameraDisplacement), cameraDistance), lerpSpeed);
    }
}
