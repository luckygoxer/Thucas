using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform barrelTip;
    [SerializeField]
    private float cooldown = 5.0f;
    private float cooldownCounter = 0.0f;

    public GameObject cannonBallPrefab;

    void Start()
    {
        cooldownCounter = cooldown;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        cooldownCounter -= Time.deltaTime;

        if (target != null)
        {
            Vector3 aimDirection = target.position - barrelTip.position;
            
            RaycastHit hitInfo;
    
            if (Physics.Raycast(barrelTip.position, aimDirection.normalized, out hitInfo) &&
                hitInfo.transform == target && cooldownCounter <= 0)
            {
                ShootCannon();
                cooldownCounter = cooldown;
            }
        }
    }
    void ShootCannon()
    {
        Instantiate(cannonBallPrefab, barrelTip.transform.position, barrelTip.transform.rotation);
    }
}
