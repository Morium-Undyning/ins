using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    
    public float speed = 10f;
    public float JumpForce = 300f;
    private bool _isGrounded;
    private Rigidbody rb;
    public float turnSpeed = 300f;
    public Animator anim;
    GameObject pl;
    GameObject pl1;
    public float TimeAnim;
    GameObject UpL;
    public GameObject UpS;
    public bool ropes;
    private CharacterJoint cj;
    public bool UpB;
    public bool ropeB;
    public GameObject play;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cj = GetComponent<CharacterJoint>();
        UpS = GameObject.Find("HGH");
        if(cj!= null)
        cj.connectedBody = UpS.GetComponent<Rigidbody>();
        pl = GameObject.Find("Panel");
        pl1 = GameObject.Find("pal");
        UpL = GameObject.Find("Up");
    }

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
        Anima();
        TimeAnim -=Time.deltaTime;
        if(TimeAnim<=0){
            anim.SetBool("UpLabber",false);
            if(UpB==true){
                transform.position = UpL.transform.position;
                UpB = false;
            }
            

        }
       
    }
     private void MovementLogic()
    {
        if(ropes == true)
        {
            if(Input.GetKey(KeyCode.W)){
        rb.AddForce(Vector3.forward * JumpForce);
       }
       
       else if(Input.GetKey(KeyCode.S)){
        rb.AddForce(-Vector3.forward * JumpForce);
       }
        }
        else{
            if(Input.GetKey(KeyCode.W)){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
       }
       
       else if(Input.GetKey(KeyCode.S)){
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
       }
       
       if(Input.GetKey(KeyCode.A)){
        transform.Rotate(Vector3.up,  -turnSpeed * Time.deltaTime);
       }
       
       else if(Input.GetKey(KeyCode.D)){
        transform.Rotate(Vector3.up,  turnSpeed * Time.deltaTime);
       }
        }
        
    }
    private void Anima(){
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)){
            anim.SetBool("IsRun",true);
        }else{
            anim.SetBool("IsRun",false);
        }
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                rb.AddForce(Vector3.up * JumpForce);

            }
        }
    }
    void OnTriggerEnter (Collider other){
        if(other.tag == "rope")
        ropeB = true;

    }
    void OnTriggerExit (Collider other){
        if(other.tag == "rope")
        ropeB = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
    
}

