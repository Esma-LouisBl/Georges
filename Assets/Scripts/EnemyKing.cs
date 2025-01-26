using UnityEngine;

public class EnemyKing : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    public int lives = 75;

    [SerializeField]
    private SceneSwitch _sceneSwitch;


    public void Touched()
    {
        if (lives > 0)
        {
            lives--;
        }
        else
        {
            Destroy(gameObject);
            _sceneSwitch.ChangeScene("TheEnd");
        }
    }
}
