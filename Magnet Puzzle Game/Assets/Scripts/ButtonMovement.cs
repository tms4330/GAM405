using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3 offsetPosition = Vector3.zero;

    public Animator animator;
    

    [SerializeField] private Vector3 startPos = Vector3.zero;
    private bool isOpen = false;

    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (isOpen && transform.position != offsetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, offsetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, moveSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isOpen = true;
        animator.SetBool("isOn", true);
        Debug.Log("InTrigger");
    }

    private void OnTriggerExit(Collider other)
    {
        isOpen = false;
        animator.SetBool("isOn", false);
        Debug.Log("OutTrigger");
    }
}
