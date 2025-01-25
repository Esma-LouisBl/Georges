using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private GameObject _chocWave;
    private Transform _initialChocWave;
    private int i = 6, j = 20;

    void Start()
    {
        _initialChocWave = gameObject.transform;
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
        StartCoroutine(ChocWave());
    }

    private IEnumerator ChocWave()
    {
        _chocWave.transform.localScale = _initialChocWave.localScale;
        while (j > 0)
        {
            _chocWave.transform.localScale += new Vector3 (0.5f, 0, 0.5f);
            yield return new WaitForSeconds(0.1f);
            j -= 1;
        }
    }
}
