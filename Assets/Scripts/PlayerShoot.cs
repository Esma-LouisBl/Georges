using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ProjectilesBehavior ProjectilePrefab;
    public Transform LaunchOffset;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.identity;
            Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation);
            //Quaternion.Euler(transform.rotation.x, transform.rotationy, transform.rotation.z));
        }
    }
}
