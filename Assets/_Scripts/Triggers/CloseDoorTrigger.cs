using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{

    [SerializeField] private Animator door;
    [SerializeField] private AudioSource doorAudioSource;
    [SerializeField] private AudioClip closeDoorAudio;
    
    [SerializeField] private bool isActiveAfter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorAudioSource.PlayOneShot(closeDoorAudio);
            door.SetBool("OpenDoor", false);
            door.gameObject.GetComponent<DoorScript>().isOpened = false;
            if(!isActiveAfter)
                door.gameObject.layer = 0;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
