using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBridge : MonoBehaviour
{
    [SerializeField]
    private GameObject _bridge;
    [SerializeField]
    private Enemy _enemy;


    [SerializeField]
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Bubble"))
        //{
        //    Debug.Log("skibidi");
        //    _bridge.SetActive(true);
        //    Destroy(collision.gameObject);
        //}
        if (collision.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(collision.gameObject);
        }
    }
}
