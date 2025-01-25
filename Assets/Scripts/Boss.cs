using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField]
    private int _lives = 10;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("skibidi zob");
        if (other.gameObject.CompareTag("Bubble"))
        {
            Touched();

            Destroy(other.gameObject);
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
