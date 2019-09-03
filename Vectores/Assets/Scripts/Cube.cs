using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Vector3 velocity = new Vector3(-4, 8, 0);
    Vector3 acceleration = new Vector3(0, -9.8f, 0);

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;
        CheckBounce();
    }

    void CheckBounce()
    {
        if(transform.position.y <= -4.5f || transform.position.y >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f * Mathf.Sign(velocity.y));
            velocity.y = -velocity.y;
        }
        if(transform.position.x <= -9.5f || transform.position.x >= 9.5f)
        {
            velocity.x = -velocity.x;
        }
    }
}