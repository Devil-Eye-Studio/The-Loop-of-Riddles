using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTrigger : MonoBehaviour
{
    [SerializeField] private GameObject deleteGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            deleteGameObject.SetActive(false);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
