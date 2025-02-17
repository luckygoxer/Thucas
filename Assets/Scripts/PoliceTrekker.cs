using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceTrekker : MonoBehaviour
{
    public Transform trekker;
    public float speed = 5f;

    void Update()
    {
        if (trekker != null)
        {
            // Calculate the direction to the trekker
            Vector3 direction = (trekker.position - transform.position).normalized;

            // Rotate the police to face the trekker
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

            // Move the police towards the trekker
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
