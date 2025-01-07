#pragma warning disable CS0618 // Menghilangkan peringatan 'velocity' usang
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jumpScale ;
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator animator;
    public bool isground, iswall;
    public GameObject soal, gameover, finish, dino;
    public AudioSource jump_audio, soal_audio, walk_audio, fall_audio, finish_audio, backsound_audio;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !iswall)
        {
            runight();
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !iswall)
        {
            runleft();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            stop();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isground)
        {
            Jump();
        }
        if(transform.localPosition.y<-10){
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        updateanimation();

    }

    int soalaktif (){
        return soal.GetComponent<soalmanager>().nomor();
    }

    public void runight(){   
        Debug.Log("Bergerak ke kanan.");
            if (soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){
                body.velocity = new Vector2(speed, body.velocity.y);
                sprite.flipX = false;
            }

    }
    public void runleft(){
        Debug.Log("Bergerak ke kiri.");
        if (soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){
            body.velocity = new Vector2(-speed, body.velocity.y);
            sprite.flipX = true;
        }
    }
    public void stop(){
        if (soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){
        body.velocity = new Vector2(0, body.velocity.y);
        }
    }
    public void Jump(){
            if (isground)
        {
            Debug.Log("Pemain melompat.");
            if (soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){
                body.velocity = new Vector2(body.velocity.x, jumpScale);
                isground = false;
                jump_audio.Play();
            }
        }
    }

    void updateanimation(){
        if(body.velocity.y>0.01f){
            animator.SetInteger("state",2);
            walk_audio.Stop();
        } else if(body.velocity.y<-0.01f){
            animator.SetInteger("state",3);
        }else{
            if(body.velocity.x>speed/2f || body.velocity.x<-speed/2f ){
            animator.SetInteger("state",1);
                if(!walk_audio.isPlaying && isground){
                walk_audio.Play();
                }
            } else {
            animator.SetInteger("state",0);
                walk_audio.Stop();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D obj){
        if(obj.name == "Water")
        {
            transform.Find("Main Camera").parent = null;
            fall_audio.Play();
            StartCoroutine(gameovershow());
        }
        if (obj.name == "dino")
        {
            transform.Find("Main Camera").parent = null;
            fall_audio.Play();
            StartCoroutine(gameovershow());
        }

        if (obj.tag == "pos"){
            soal_audio.Play();
            soal.transform.GetChild(obj.transform.GetSiblingIndex()).gameObject.SetActive(true);
            obj.GetComponent<SpriteRenderer>().enabled = false;
            obj.GetComponent<BoxCollider2D>().enabled = false;
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(obj.name == "finish"){
            if (soal.GetComponent<soalmanager>().soalterjawab == 5){
                finish.SetActive(true);
                backsound_audio.Stop();
                finish_audio.Play();
            }
            
        }
    } 
    IEnumerator gameovershow(){
        yield return new WaitForSeconds(0.2f);
        gameover.SetActive(true);
    } 
    IEnumerator FadeOutBacksound(float duration) {
    float startVolume = backsound_audio.volume;
    float elapsedTime = 0;

    while (elapsedTime < duration) {
        elapsedTime += Time.deltaTime;
        backsound_audio.volume = Mathf.Lerp(startVolume, 0, elapsedTime / duration);
        yield return null;
    }

    backsound_audio.Stop();
    backsound_audio.volume = startVolume; // Reset volume untuk pemutaran berikutnya
}

}

