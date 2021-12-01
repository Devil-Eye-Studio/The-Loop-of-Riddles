using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DynamicDepthOfField : MonoBehaviour
{

    [SerializeField] private PostProcessVolume volume;

    [SerializeField] private float focusSpeed;
    [SerializeField] private float maxFocusDistance;

    Ray rayCast;
    RaycastHit hit;
    float hitDistance;

    DepthOfField depthOfField;

    private void Start()
    {
        volume.profile.TryGetSettings(out depthOfField);
    }

    private void Update()
    {
        rayCast = new Ray(transform.position, transform.forward * maxFocusDistance);

        if(Physics.Raycast(rayCast, out hit, maxFocusDistance))
        {
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }
        else
        {
            if (hitDistance < maxFocusDistance)
            {
                hitDistance++;
            }
        }
        SetFocus();
    }   

    void SetFocus()
    {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, focusSpeed * Time.deltaTime);
    }
}
