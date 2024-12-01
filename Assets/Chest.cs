using UnityEngine;

public class Gold : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Altýn toplandýðýnda ne olacaðýný yaz
            Destroy(gameObject);
        }
    }
}
