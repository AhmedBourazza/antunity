using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketMovement : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

