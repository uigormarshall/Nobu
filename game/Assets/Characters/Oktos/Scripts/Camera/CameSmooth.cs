using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameSmooth : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.09f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 startPosition = new Vector3(target.position.x, target.position.y, -1f);
        Vector3 endPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
        transform.position = endPosition;
    }
}
