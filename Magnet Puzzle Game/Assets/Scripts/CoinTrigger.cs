using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public GameObject coinDoor;
    public GameObject coin;

    private void OnTriggerEnter(Collider other)
    {
        coin.SetActive(false);
        coinDoor.SetActive(false);
    }
}
