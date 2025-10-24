using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] OpeningDoor od;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magnetised") od.OpenDoor();
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Magnetised") od.CloseDoor();
    }

}
