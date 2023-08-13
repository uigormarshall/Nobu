using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameSmooth : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.09f;
    [SerializeField] private float xDelta = 2f;
    [SerializeField] private float yDelta = 3f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float moveInput = Input.GetAxisRaw("Horizontal");
        float moveInputVertical = Input.GetAxisRaw("Vertical");
        Vector3 startPosition = new Vector3(target.position.x + (moveInput*xDelta), target.position.y + (moveInputVertical*yDelta), -1f);
        Vector3 endPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
        transform.position = endPosition;
    }
}
