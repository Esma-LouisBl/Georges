using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -100)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }

    [SerializeField] private float _sensetivity = 10;
    private float _xRotation;
    private Vector2 _playerMouseInput;

    public Transform head;

void Start()
{
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
}


void Update()
{
    transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f); //permet de tourner son champ de vision autour de soi

    _xRotation -= _playerMouseInput.y * _sensetivity;
    _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
}

private void LateUpdate()
{
    Vector3 e = head.eulerAngles;
    e.x -= Input.GetAxis("Mouse Y") * 2f; //2f : represente la vitesse a laquelle la camera monte
    e.x = RestrictAngle(e.x, -85f, 85f);
    head.eulerAngles = e;
}
}
