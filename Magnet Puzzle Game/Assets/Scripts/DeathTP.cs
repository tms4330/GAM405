using UnityEngine;

public class DeathTP : MonoBehaviour
{
    public Transform teleportTarget; //Teleport position target
    GameObject teleportee; //The object that is getting teleported
    private void OnTriggerEnter(Collider other)
    {
        CanBeTPd check = other.GetComponent<CanBeTPd>();
        if (check != null)
        {
            teleportee = other.gameObject;
            teleportee.transform.position = teleportTarget.transform.position;
        }
    }
}
