using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public static float RestrictAngle(float angle, float angleMin, float angleMax) //parametre la verification et la remise a niveau des maximums et minimums de l'angle de camera
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

    public Transform head; //gameobject representant la tete du joueur

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _camera;

    private bool _isWalking = false;
    private bool _handsUp = false;


    void Start()
    {
        Cursor.visible = false; //cache le curseur
        Cursor.lockState = CursorLockMode.Locked; //bloque le curseur au centre de l'ecran

        //_isWalking = true;
        StartCoroutine(Shaking());
    }


    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f); //tourne la camera sur l'axe horizontal
    }

    private void LateUpdate()
    {
        gameObject.transform.localPosition = _player.transform.localPosition;

        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f; //2f : represente la vitesse a laquelle la camera monte
        e.x = RestrictAngle(e.x, -85f, 85f); //bloque la rotation de la camera
        head.eulerAngles = e; //tourne la camera sur l'axe vertical
    }

    private IEnumerator Shaking() //rajouter les conditions grounded
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            if (_isWalking)
            {
                if (_handsUp)
                {
                    _camera.transform.position += new Vector3(0, 0.1f, 0);
                    _handsUp = false;
                }
                else
                {
                    _camera.transform.position += new Vector3(0, -0.1f, 0);
                    _handsUp = true;
                }
            }
        }
    }
}