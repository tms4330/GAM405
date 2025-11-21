using Unity.VisualScripting;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject cam;
    public GameObject canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam.GetComponent<CamMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;

    }

    public void onPress()
    {
        canvas.SetActive(false);
        cam.GetComponent<CamMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void onQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
