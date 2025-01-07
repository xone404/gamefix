using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject poinA;
    public GameObject poinB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform curentPoint;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curentPoint = poinB.transform;
        anim.SetBool("isRunning", true);

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = curentPoint.position -  transform.position;
        if (curentPoint == poinB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2 (-speed, 0);
        }
        if(Vector2.Distance(transform.position,curentPoint.position)  <0.5f && curentPoint == poinB.transform)
        {
            flip();
            curentPoint = poinA.transform;
        }
        if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == poinA.transform)
        {
            flip();
            curentPoint = poinB.transform;
        }
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(poinA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(poinB.transform.position, 0.5f);
        Gizmos.DrawLine(poinA.transform.position, poinB.transform.position);
    }

}
