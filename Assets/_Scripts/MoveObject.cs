using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 movePosition;

    private new BoxCollider collider;
    private Vector3 startPosition;
    
    public bool isMove;

    void Start()
    {
        startPosition = transform.position;
        collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (isMove) 
        {
            collider.enabled = false;
            transform.position = Vector3.Lerp(transform.position, movePosition, moveSpeed * Time.deltaTime);
        }
        
    }
}
