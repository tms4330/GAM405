using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    public Transform reset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lava")
        {
            transform.position = reset.position;
        }
    }


    
}
