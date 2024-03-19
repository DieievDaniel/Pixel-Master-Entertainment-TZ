using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float rotateSpeed;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float rotationX = touchDeltaPosition.x * rotateSpeed * Time.deltaTime;
            transform.RotateAround(target.position, Vector3.up, rotationX);
        }
    }
}
