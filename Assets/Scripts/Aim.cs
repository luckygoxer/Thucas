using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform barrelPivot;
    [SerializeField]
    private Transform barrelTip;
    private Quaternion currentRotation;
    [SerializeField]
    private float rotationSpeed = .5f;
    void Start()
    {
        currentRotation = transform.rotation;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 aimDirection = target.position - barrelPivot.position;

            RaycastHit hitInfo;
            if (Physics.Raycast(barrelTip.position, aimDirection.normalized, out hitInfo) &&
                    hitInfo.transform == target)
            {
                Quaternion lookRotation = Quaternion.LookRotation(aimDirection);
                Quaternion lerpRotation = Quaternion.Lerp(currentRotation, lookRotation, Time.deltaTime * rotationSpeed);
                currentRotation = lerpRotation;
                
                transform.rotation = Quaternion.Euler(0.0f, lerpRotation.eulerAngles.y, 0.0f);
                barrelPivot.localRotation = Quaternion.Euler(lerpRotation.eulerAngles.x, 0.0f, 0.0f);
            }
            Debug.DrawLine(barrelTip.position, target.position, Color.yellow);
        }
    }
}
