using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool isOpened;
    public bool isLocked;
    public bool isScriptableDoor;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] doorSounds;

    public void OpenDoor()
    {
        animator.SetBool("OpenDoor", true);
        isOpened = true;
        if(isScriptableDoor) gameObject.layer = 0;
        audioSource.PlayOneShot(doorSounds[0]);
    }
    public void CloseDoor()
    {
        animator.SetBool("OpenDoor", false);
        isOpened = false;
        audioSource.PlayOneShot(doorSounds[1]);
    }
}
