using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreakhir : MonoBehaviour
{
    public TMP_Text skor_T, rangking_T;
    public soalmanager soal;

    void Start()
    {
        skor_T.text = soal.skor.ToString();
        if(soal.skor>80){
            rangking_T.text = "Exellent !";
        } else if (soal.skor>60){
            rangking_T.text = "Good Effort !";
        } else {
            rangking_T.text = "Keep Trying !";      
        }
    }
}
