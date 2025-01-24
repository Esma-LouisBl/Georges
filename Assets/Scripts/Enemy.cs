using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed = 3;

    private bool _goLeft = true;
    public GameObject point1;
    public GameObject point2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_goLeft)
        {
            _rb.velocity = Vector3.forward * _speed;
        }
        else
        {
            _rb.velocity = Vector3.back * _speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Point1"))
        {
            _goLeft = false;
        }

        if (collision.gameObject.CompareTag("Point2"))
        {
            _goLeft = true;
        }
    }
}
