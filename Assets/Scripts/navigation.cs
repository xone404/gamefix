using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class navigation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    public Player Player;
    int nav = 0;
public void OnPointerDown(PointerEventData pointerEventData){
    if ( gameObject.name == "GUI Left"){
        nav = 1;
    }
    if (gameObject.name == "GUI Right"){
        nav = 2;
    }
    if (gameObject.name == "GUI Jump"){
        Player.Jump();

    }
}
public void OnPointerUp(PointerEventData pointerEventData){
    if ( gameObject.name == "GUI Left" || gameObject.name == "GUI Right"){
        nav = 0;
        Player.stop();
    }

}

void Update(){
    if ( nav == 1 ){
        Player.runleft();
    }else if ( nav == 2) { 
        Player.runight();
    }
}
}