using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBridge : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed = 3;

    [SerializeField]
    private int _lives = 3;

    private bool _goForward = true;
    public GameObject point1;
    public GameObject point2;

    [SerializeField]
    private Mission _mission;

    [SerializeField]
    private GameObject _bridge;

    [SerializeField]
    private GameObject _george;
    // Start is called before the first frame update
    void Start()
    {
        _bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_goForward)
        {
            _rb.velocity = transform.TransformDirection(Vector3.forward) * _speed;
        }
        else
        {
            _rb.velocity = transform.TransformDirection(Vector3.back) * _speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == point1)
        {
            _goForward = false;
            _george.transform.Rotate(new Vector3(0, 180, 0), Space.World);
        }

        if (collision.gameObject == point2)
        {
            _goForward = true;
            _george.transform.Rotate(new Vector3(0, 180, 0), Space.World);
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
            _mission.tutoGeorges = false;

            _bridge.SetActive(true);
        }
    }
}
