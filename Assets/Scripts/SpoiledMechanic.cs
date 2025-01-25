using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoiledMechanic : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(collision.gameObject);
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
