using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RToRestart : MonoBehaviour
{
    public string SceneName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Restart();
        }

        if (Input.GetKey("escape"))
        {
            Quit();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneName);
    }

    void Quit()
    {
        Application.Quit();
    }
}
