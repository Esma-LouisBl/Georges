using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocWave : MonoBehaviour
{
    [SerializeField]
    private GameObject _chocWave;
    private Transform _initialChocWave;
    private int j = 20;

    void Start()
    {
        _initialChocWave = gameObject.transform;
        StartCoroutine(ChockingWave());
    }
    private IEnumerator ChockingWave()
    {
        _chocWave.transform.localScale = _initialChocWave.localScale;
        while (j > 0)
        {
            _chocWave.transform.localScale += new Vector3(0.5f, 0, 0.5f);
            yield return new WaitForSeconds(0.1f);
            j -= 1;
        }
        Destroy(gameObject);
    }
}
