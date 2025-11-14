using UnityEngine;

public class BoyancyScript : MonoBehaviour
{
    public Transform tpPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("DIE");
            other.transform.position = tpPos.position;
            if (other.gameObject.GetComponent<Rigidbody>() != null) { other.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; }
        }
    }
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag != ("Magnetised"))
        {
            Debug.Log("DIE");
            collision.transform.position = tpPos.position;
            if (collision.gameObject.GetComponent<Rigidbody>() != null) { collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; }
        }
    }
}
