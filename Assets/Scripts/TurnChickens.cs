using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChickens : MonoBehaviour
{
    public float turnSpeed = 90f;
    public float turnCooldown = 0f;

    void Update()
    {
        turnCooldown += Time.deltaTime;

        if (turnCooldown >= 2 && turnCooldown <= 2.1)
        {
            turnSpeed = Random.Range(50f, 70f);
        }

        if (turnCooldown >= 4)
        {
            transform.Rotate(new Vector3(0, -1, 0) * turnSpeed * Time.deltaTime);
        }

        if (turnCooldown >= 6)
        {
            transform.Rotate(new Vector3(0, 1, 0) * turnSpeed * Time.deltaTime);
        }

        if (turnCooldown >= 9 && turnCooldown <= 9.1)
        {
            turnSpeed = Random.Range(50f, 70f);
        }

        if (turnCooldown >= 11)
        {
            transform.Rotate(new Vector3(0, 1, 0) * turnSpeed * Time.deltaTime);
        }

        if (turnCooldown >= 13)
        {
            turnCooldown = 0;
        }
    }
}
