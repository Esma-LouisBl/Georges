using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOrient : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;

    void Update()
    {
        gameObject.transform.rotation = _camera.transform.rotation;
    }
}
