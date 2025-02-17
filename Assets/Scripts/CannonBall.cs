using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed = 100;
    Rigidbody rb;

    [SerializeField]
    private float cooldown = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= 2)
        {
            Destroy(gameObject);
        }
    }
}
