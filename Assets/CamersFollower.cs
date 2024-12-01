//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public Transform target; // Takip edilecek nesne
//    public Vector3 offset;   // Kameranýn mesafesi ve açýsý
//    public float smoothSpeed = 0.125f; // Kameranýn takip etme hýzý

//    void LateUpdate()
//    {
//        if (target != null)
//        {
//            // Hedef pozisyonunu hesapla
//            Vector3 desiredPosition = target.position + offset;
//            // Kamerayý yumuþak bir þekilde hareket ettir
//            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//            transform.position = smoothedPosition;

//            // Kameranýn hedefe bakmasýný saðla (isteðe baðlý)
//            transform.LookAt(target);
//        }
//    }
//}
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;  // Oyuncunun Transform'u
    public Transform enemy;   // Düþmanýn Transform'u
    public float switchInterval = 30f; // Kaç saniyede bir geçiþ yapýlacak

    private Transform currentTarget; // Þu anda takip edilen hedef
    private float timer;             // Geçiþ zamanlayýcýsý
    public Vector3 offset = new Vector3(0, 5, -10); // Kameranýn hedefe göre pozisyonu
    public float smoothSpeed = 0.125f; // Kameranýn yumuþaklýðý

    private void Start()
    {
        // Baþlangýçta oyuncuyu takip et
        currentTarget = player;
        timer = 0f;
    }

    private void LateUpdate()
    {
        // Zamanlayýcýyý güncelle
        timer += Time.deltaTime;

        // Eðer zamanlayýcý süreyi geçtiyse hedef deðiþtir
        if (timer >= switchInterval)
        {
            currentTarget = currentTarget == player ? enemy : player;
            timer = 0f; // Zamanlayýcýyý sýfýrla
        }

        // Hedef pozisyonunu hesapla ve kamerayý hareket ettir
        if (currentTarget != null)
        {
            Vector3 desiredPosition = currentTarget.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Kameranýn hedefe bakmasýný saðla (isteðe baðlý)
            transform.LookAt(currentTarget);
        }
    }
}
