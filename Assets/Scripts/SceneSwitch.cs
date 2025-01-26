using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void ChangeScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
