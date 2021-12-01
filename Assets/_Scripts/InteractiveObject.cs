using UnityEngine;

public class InteractiveObject : MonoBehaviour
{

    public Vector3 startPosition;
    private Quaternion startRotation;

    private ObjectInspection objectInspection;

    public bool isPutBack;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if(isPutBack)
        {
            PutBack();
        }
    }

    public void PutBack()
    {
        transform.position = Vector3.Lerp(transform.position, startPosition, 15f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, 15f * Time.deltaTime);
    }
}
