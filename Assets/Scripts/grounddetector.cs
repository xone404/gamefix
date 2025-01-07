using UnityEngine;

public class grounddetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Ground")
        {
            transform.parent.GetComponent<Player>().isground = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.name == "Ground")
        {
            transform.parent.GetComponent<Player>().isground = false;
        }
    }
}

