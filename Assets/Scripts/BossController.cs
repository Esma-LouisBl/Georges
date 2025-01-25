using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour

{
    private int i = 6;
    public ChocWave WavePrefab;

    public Transform SpawnOffset;

    void Start()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while (i > 0)
        {
            yield return new WaitForSeconds(0.07f);
            transform.localPosition += new Vector3(0, 0.2f, 0);
            i -= 1;
        }
        i = 4;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.15f);
            transform.localPosition += new Vector3(0, 0.2f, 0);
            i -= 1;
        }
        i = 4;
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        while (i > 0)
        {
            yield return new WaitForSeconds(0.15f);
            transform.localPosition += new Vector3(0, -0.2f, 0);
            i -= 1;
        }
        i = 6;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.07f);
            transform.localPosition += new Vector3(0, -0.2f, 0);
            i -= 1;
        }
        i = 6;
        StartCoroutine(Jump());
        Instantiate(WavePrefab, SpawnOffset.position, SpawnOffset.rotation);
    }
}
