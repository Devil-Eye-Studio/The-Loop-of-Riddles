using UnityEngine;

public class ObjectInspection : MonoBehaviour
{

    [SerializeField] private float objectSensitivity;

    [SerializeField] private float minX = -360f;
    [SerializeField] private float maxX = 360f;

    [SerializeField] private float minY = 360f;
    [SerializeField] private float maxY = 360f;

    float xRot;
    float yRot;

    Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxisRaw("Mouse X") * objectSensitivity;
            yRot += Input.GetAxisRaw("Mouse Y") * objectSensitivity;

            xRot = ClampAngle(xRot, minX, maxX);
            yRot = ClampAngle(yRot, minY, maxY);

            Quaternion xQuaternion = Quaternion.AngleAxis(xRot, -Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(yRot, -Vector3.right);
            transform.localRotation = startRotation * xQuaternion * yQuaternion;
        }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
