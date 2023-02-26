using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zero : MonoBehaviour
{
    public Player play;
    void Start()
    {
        
    }

    
    void Update()
    {
        play = GameObject.FindObjectOfType<Player>();
    }

    public void LabberUp(){
        play.anim.SetBool("UpLabber",true);
        play.TimeAnim = 1.5f;
        play.UpB = true;
        
    }
    public void Rope(){
        if( play.ropeB == true){
            Instantiate(play.play,play.UpS.transform.position,play.transform.rotation);
            Destroy(play.gameObject);
        }
    }
}
