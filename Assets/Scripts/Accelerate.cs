using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accelerate : MonoBehaviour
{
    private Rigidbody rb;

    public float accelaration = 80f;
    public float groundFriction = 0.5f;
    public float groundFrictionElse = 0.8f;

    public bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isAlive = true;
    }

    void FixedUpdate()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "Welcome" && currentSceneName != "Win")
        {
            if (isAlive == true)
            {
                if (IsGrounded())
                {
                    rb.AddForce(transform.forward * accelaration * Input.GetAxis("Vertical"));
                }
            }
        }
    }

    public bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f; // Slightly raise the origin to avoid false negatives
        Vector3 direction = Vector3.down;
        float distance = 1f; // Adjust the distance

        Debug.DrawLine(origin, origin + direction * distance, Color.red);

        RaycastHit hitInfo;

        if (Physics.Raycast(origin, direction, out hitInfo, distance))
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.gameObject.CompareTag("Road"))
                {
                    rb.velocity *= groundFriction;
                }
                else
                {
                    rb.velocity *= groundFrictionElse; // Ensure groundFrictionElse is less than 1
                    rb.AddForce(-rb.velocity * (1 - groundFrictionElse), ForceMode.Acceleration); // Apply deceleration force
                }
                return true;
            }
        }
        return false;
    }
}
