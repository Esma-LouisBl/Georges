using UnityEngine;

public class Enemy : MonoBehaviour
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
    private GameObject _george;

    [SerializeField]
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource.Play();
    }
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

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject == point1)
        {
            _goForward = false;
            _george.transform.Rotate(new Vector3(0,180,0), Space.World);
        }

        if (collider.gameObject == point2)
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
        }
    }
}
