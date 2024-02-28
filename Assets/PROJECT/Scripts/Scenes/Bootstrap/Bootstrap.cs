using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        CameraC.Init();
        Settings.Init();

        SceneManager.LoadScene("Scene_1");
    }
}