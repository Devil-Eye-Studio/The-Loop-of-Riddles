using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    [SerializeField] private GameObject lampObject;
    [SerializeField] private AudioClip switchAudio;

    [SerializeField] private MeshRenderer lampHead;

    [SerializeField] private Material glowMaterial;
    [SerializeField] private Material darkMaterial;

    private AudioSource audioSource;
    private Animator animator;

    public bool isOn; // Checking if the light is on

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isOn) lampHead.material = darkMaterial;
        else lampHead.material = glowMaterial;
    }

    public void TurnOn()
    {
        lampObject.SetActive(true);
        isOn = true;
        lampHead.material = glowMaterial;
        audioSource.PlayOneShot(switchAudio);
        animator.SetBool("IsOn", true);
    }

    public void TurnOff()
    {
        lampObject.SetActive(false);
        isOn = false;
        audioSource.PlayOneShot(switchAudio);
        lampHead.material = darkMaterial;
        animator.SetBool("IsOn", false);
    }
}
