using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float sensitivity = -1f;
    private float x;
    private float y;
    private Vector3 rotate;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        // For Following Player
        transform.position = new Vector3(playerTransform.position.x, 1.75f, playerTransform.position.z + 3f);

        // For Camera Rotation
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x, y * sensitivity, 0);
        transform.eulerAngles -= rotate;
    }
}