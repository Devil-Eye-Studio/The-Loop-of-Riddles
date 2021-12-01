using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{

    [SerializeField] private GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            trigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
