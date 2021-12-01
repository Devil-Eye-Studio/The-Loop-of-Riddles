using UnityEngine;

public class Locker : MonoBehaviour
{

    [SerializeField] private float openSpeed;
    [SerializeField] private Vector3 lockerOffset;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] lockerSounds;

    private Vector3 lockerEndTransform;

    public bool isOpen;

    void Start()
    {
        startPosition = transform.position;
        lockerEndTransform = transform.position + lockerOffset;
    }

    void Update()
    {
        if(isOpen) transform.position = Vector3.Lerp(transform.position, lockerEndTransform, openSpeed * Time.deltaTime);
        else transform.position = Vector3.Lerp(transform.position, startPosition, openSpeed * Time.deltaTime);
    }

    public void OpenLocker()
    {       
        isOpen = true;
        audioSource.PlayOneShot(lockerSounds[0]);
    }

    public void CloseLocker()
    {       
        isOpen = false;
        audioSource.PlayOneShot(lockerSounds[1]);
    }
}
