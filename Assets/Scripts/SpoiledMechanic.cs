using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoiledMechanic : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Te");
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ti");
        if (other.gameObject.CompareTag("Bubble"))
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }
}
//{
//    [SerializeField]
//    private GameObject _anchor;

//    void Start()
//    {
        
//    }

//    void Update()
//    {
        
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        Debug.Log("youhou");
//        if (collision.gameObject.CompareTag("Bubble"))
//        {
//            Debug.Log("Teemo");
//            _anchor.transform.Rotate(0, 90, 0, Space.World);
//        }
//    }
//}
