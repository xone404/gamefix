using UnityEngine;

public class walldetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Wall")) // Pastikan hanya mendeteksi tag "Wall"
        {
            transform.parent.GetComponent<Player>().iswall = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Wall")) // Keluar dari tag "Wall"
        {
            transform.parent.GetComponent<Player>().iswall = false;
        }
    }
}
