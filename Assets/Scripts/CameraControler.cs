using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    public bool _isGrounded = false;
    private Vector3 lastPosition;
    private int i = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //bloque le curseur au centre de l'ecran

        //_isWalking = true;
        StartCoroutine(Shaking());
        lastPosition = gameObject.transform.localPosition;
    }


    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f); //tourne la camera sur l'axe horizontal

        if (lastPosition != gameObject.transform.localPosition && _isGrounded)
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
        lastPosition = transform.localPosition;

        if (gameObject.transform.localPosition.y > 3)
        {
            _isGrounded = false;
        }
        else
        {
            _isGrounded = true;
        }
    }

    private void LateUpdate()
    {
        gameObject.transform.localPosition = _player.transform.localPosition;
    }

    private IEnumerator Shaking() //rajouter les conditions grounded
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (_isWalking)
            {
                if (_handsUp)
                {
                    if (i > 0)
                    {
                        _camera.transform.position += new Vector3(0, 0.02f, 0);
                        _handsUp = false;
                        i -= 1;
                    }
                }
                else
                {
                    if (i < 20)
                    {
                        _camera.transform.position += new Vector3(0, -0.02f, 0);
                        _handsUp = true;
                        i += 1;
                    }
                }
            }
        }
    }
}