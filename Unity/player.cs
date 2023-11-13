using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 5f;
    
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        body.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
    }
}
