using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGain = 0.2f;
    void Start()
    {
        
    }

    void Update()
    {
        speed += speedGain * Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
