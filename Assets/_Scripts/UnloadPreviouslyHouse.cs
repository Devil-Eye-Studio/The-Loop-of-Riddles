using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadPreviouslyHouse : MonoBehaviour
{

    [SerializeField] private GameObject previouslyHouse;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("UnloadInvoke", 5f);
            gameObject.SetActive(false);
        }
    }

    private void UnloadInvoke()
    {
        previouslyHouse.SetActive(false);
    }
}
