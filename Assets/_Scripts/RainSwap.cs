using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSwap : MonoBehaviour
{

    [SerializeField] private float volumeSpeed;
    [SerializeField] private AudioSource[] rainSpots;

    private bool isInTrigger;


    private void Update()
    {
        if (isInTrigger)
        {
            rainSpots[0].volume -= Time.deltaTime * volumeSpeed;
            rainSpots[1].volume += Time.deltaTime * volumeSpeed;
        }
        else
        {
            rainSpots[1].volume -= Time.deltaTime * volumeSpeed;
            rainSpots[0].volume += Time.deltaTime * volumeSpeed;
        }
        for (int i = 0; i < rainSpots.Length; i++)
        {
            if(rainSpots[i].volume > .25f) rainSpots[i].volume = .25f;
        }   
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            isInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }
}
