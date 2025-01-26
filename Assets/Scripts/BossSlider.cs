using UnityEngine;
using UnityEngine.UI;

public class BossSlider : MonoBehaviour
{
    [SerializeField]
    private EnemyKing _enemyKing;
    [SerializeField]
    private Slider _gauge;
    // Start is called before the first frame update
    void Start()
    {
        _gauge.maxValue = _enemyKing.lives;
        _gauge.value = _enemyKing.lives;

    }

    // Update is called once per frame
    void Update()
    {
        _gauge.value = _enemyKing.lives;
    }
}
