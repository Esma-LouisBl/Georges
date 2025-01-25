using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed = 3;

    [SerializeField]
    private int _lives = 3;

    private bool _goForward = true;
    private bool _goBack = false;
    private bool _goLeft = false;
    private bool _goRight = false;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_goForward)
        {
            _rb.velocity = Vector3.forward * _speed;
        }
        if (_goLeft)
        {
            _rb.velocity = Vector3.left * _speed;
        }
        if (_goRight)
        {
            _rb.velocity = Vector3.right * _speed;
        }
        if (_goBack)
        {
            _rb.velocity = Vector3.back * _speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == point1)
        {
            _goForward = false;
            _goRight = true;
        }

        if (collision.gameObject == point2)
        {
            _goRight = false;
            _goBack = true;
        }

        if (collision.gameObject == point3)
        {
            _goBack = false;
            _goLeft = true;
        }

        if (collision.gameObject == point4)
        {
            _goLeft = false;
            _goForward = true;
        }
    }
    public void Touched()
    {
        if (_lives > 1)
        {
            _lives--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
