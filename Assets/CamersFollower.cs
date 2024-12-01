//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public Transform target; // Takip edilecek nesne
//    public Vector3 offset;   // Kameran�n mesafesi ve a��s�
//    public float smoothSpeed = 0.125f; // Kameran�n takip etme h�z�

//    void LateUpdate()
//    {
//        if (target != null)
//        {
//            // Hedef pozisyonunu hesapla
//            Vector3 desiredPosition = target.position + offset;
//            // Kameray� yumu�ak bir �ekilde hareket ettir
//            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//            transform.position = smoothedPosition;

//            // Kameran�n hedefe bakmas�n� sa�la (iste�e ba�l�)
//            transform.LookAt(target);
//        }
//    }
//}
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;  // Oyuncunun Transform'u
    public Transform enemy;   // D��man�n Transform'u
    public float switchInterval = 30f; // Ka� saniyede bir ge�i� yap�lacak

    private Transform currentTarget; // �u anda takip edilen hedef
    private float timer;             // Ge�i� zamanlay�c�s�
    public Vector3 offset = new Vector3(0, 5, -10); // Kameran�n hedefe g�re pozisyonu
    public float smoothSpeed = 0.125f; // Kameran�n yumu�akl���

    private void Start()
    {
        // Ba�lang��ta oyuncuyu takip et
        currentTarget = player;
        timer = 0f;
    }

    private void LateUpdate()
    {
        // Zamanlay�c�y� g�ncelle
        timer += Time.deltaTime;

        // E�er zamanlay�c� s�reyi ge�tiyse hedef de�i�tir
        if (timer >= switchInterval)
        {
            currentTarget = currentTarget == player ? enemy : player;
            timer = 0f; // Zamanlay�c�y� s�f�rla
        }

        // Hedef pozisyonunu hesapla ve kameray� hareket ettir
        if (currentTarget != null)
        {
            Vector3 desiredPosition = currentTarget.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Kameran�n hedefe bakmas�n� sa�la (iste�e ba�l�)
            transform.LookAt(currentTarget);
        }
    }
}
