using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 19f;
    public float leftOffset = .1f;
    public float rightOffset = .1f;
    public float topOffset = 1f;
    public float bottomOffset = .1f;

    private Vector3 offset;

    private void Start()
    {
        
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        
        Vector3 targetPosition = target.position + offset;
        Vector3 currentPosition = transform.position;

        
        float xDistance = Mathf.Abs(targetPosition.x - currentPosition.x);
        float yDistance = Mathf.Abs(targetPosition.y - currentPosition.y);

        // move the camera to the left
        if (targetPosition.x < currentPosition.x - leftOffset)
        {
            transform.position = Vector3.Lerp(currentPosition, new Vector3(targetPosition.x + leftOffset, currentPosition.y, currentPosition.z), smoothing * Time.fixedDeltaTime);
        }

        // move the camera to the right
        else if (targetPosition.x > currentPosition.x + rightOffset)
        {
            transform.position = Vector3.Lerp(currentPosition, new Vector3(targetPosition.x - rightOffset, currentPosition.y, currentPosition.z), smoothing * Time.fixedDeltaTime);
        }

        // move the camera up
        if (targetPosition.y > currentPosition.y + topOffset)
        {
            transform.position = Vector3.Lerp(currentPosition, new Vector3(currentPosition.x, targetPosition.y - topOffset, currentPosition.z), smoothing * Time.fixedDeltaTime);
        }

        // move the camera down
        else if (targetPosition.y < currentPosition.y - bottomOffset)
        {
            transform.position = Vector3.Lerp(currentPosition, new Vector3(currentPosition.x, targetPosition.y + bottomOffset, currentPosition.z), smoothing * Time.fixedDeltaTime);
        }
    }
}

