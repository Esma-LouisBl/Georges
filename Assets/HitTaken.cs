using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTaken : MonoBehaviour
{
    public GameObject player;

    public Transform spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.transform.position = spawner.transform.position;
        }
    }
}
