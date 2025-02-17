using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArrow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform arrowPivot;
    [SerializeField]
    private Transform arrowTip;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private Vector3 rotationOffset = new Vector3(0, 90, 0);

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Treehouse").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = (target.position - arrowPivot.position).normalized;

            // Calculate the look rotation
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Apply the rotation offset
            Quaternion offsetRotation = Quaternion.Euler(rotationOffset);
            lookRotation *= offsetRotation;

            // Rotate the arrowPivot to face the target with the offset
            arrowPivot.rotation = Quaternion.Slerp(arrowPivot.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
