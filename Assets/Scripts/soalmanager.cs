using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class soalmanager : MonoBehaviour
{
    public AudioSource benar_audio, salah_audio;
    public TMP_Text skor_T, terjawab_T;
    public Color warnatombolbenar, warnatombolsalah;
    public int soalterjawab=0, skor=0;
    public string [] kuncijawaban;

    public int nomor(){
        int a = -1;
        for(int i=0;i<transform.childCount;i++){
            if(transform.GetChild(i).gameObject.activeSelf){
                a = i;
            }
        }
        return a; 
    }



    public void jawab(GameObject tombol){
        for (int i=0;i<tombol.transform.parent.childCount;i++){
            tombol.transform.parent.GetChild(i).GetComponent<Button>().enabled = false;
        }
        if(tombol.name == kuncijawaban[nomor()]){ 
            benar_audio.Play();
            tombol.GetComponent<Image>().color = warnatombolbenar;
            skor+=20;
        } else {
            salah_audio.Play();
            tombol.GetComponent<Image>().color = warnatombolsalah;

        }
        soalterjawab++;
        StartCoroutine(tutupsoal());
    }
    IEnumerator tutupsoal(){
        yield return new WaitForSeconds(1f);
        transform.GetChild(nomor()).gameObject.SetActive(false);
    }
    void Update(){
        skor_T.text = "Skor : " + skor;
        terjawab_T.text = "soal : "+soalterjawab+" / 5";
    }
}
