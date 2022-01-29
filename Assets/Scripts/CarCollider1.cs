using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider1 : MonoBehaviour
{
    public int carHP = 12;

    public CarController Speed;


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (CollicionInfo.collider.name != "Ground")
        {
            carHP = carHP - 4
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (carHP < 1)
        {

        }
    }
}
