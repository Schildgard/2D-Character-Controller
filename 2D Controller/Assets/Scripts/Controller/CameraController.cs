using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraController : MonoBehaviour
{
    // Camera follows the Player and when and is dragable ony the Y axis

    private const float cameraDistance = -10;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float maxCameraDisplacement;

    private Vector3 initialMousePosition;

    private Vector3 camPos;
    private void Update()
    {
        // Get Mouse Position on Button Press to be able to calculate the mount movement
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }
        // Calculate how far and in which direction the mouse has moved
        if (Input.GetMouseButton(0))
        {
            float positionDifference = Mathf.Clamp(Input.mousePosition.y - initialMousePosition.y, -maxCameraDisplacement, maxCameraDisplacement);
            camPos = new Vector3(playerTransform.position.x, playerTransform.position.y + positionDifference, cameraDistance);
            transform.position = Vector3.Lerp(transform.position, camPos,lerpSpeed*Time.deltaTime);
        }
        else transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y,cameraDistance), lerpSpeed*Time.deltaTime);
    }
}
