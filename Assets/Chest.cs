using UnityEngine;

public class Gold : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Alt�n topland���nda ne olaca��n� yaz
            Destroy(gameObject);
        }
    }
}
