using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, 1.75f, playerTransform.position.z + 3f);
    }
}