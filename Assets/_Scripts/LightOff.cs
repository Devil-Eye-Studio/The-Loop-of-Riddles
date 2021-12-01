using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{

    [SerializeField] private Light lampLight;

    [SerializeField] private LightSwitch lightSwitch;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lampLight.enabled = false;
            lightSwitch.isOn = false;
            lightSwitch.gameObject.layer = 0;
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }
}
