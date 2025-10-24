using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public string SceneName;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            SceneManager.LoadScene(SceneName); // loads scene When player enter the trigger collider
        }
    }
}
