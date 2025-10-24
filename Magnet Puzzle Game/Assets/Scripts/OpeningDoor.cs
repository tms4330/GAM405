using System.Data;
using Unity.Mathematics;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    public Transform Door;
    public float distance;
    public float speed = 2f;
    public Transform axisSource;

    Vector3 doorOpen;
    Vector3 doorClosed;

    bool isOpen;
    float t;

    private void Awake()
    {
        if (axisSource == null) axisSource = transform;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorClosed = Door.position;

        Vector3 dir = axisSource.forward; 

        doorOpen = doorClosed - dir * distance;

    }

    // Update is called once per frame
    void Update()
    {
        float target = isOpen ? 1f : 0f;

        t = Mathf.Lerp(t, target, Time.deltaTime * speed);
        Door.position = Vector3.Lerp(doorClosed, doorOpen, t);

    }

    public void ToggleDoor() => isOpen = !isOpen;
    public void OpenDoor() => isOpen = true;
    public void CloseDoor() => isOpen = false;
}
