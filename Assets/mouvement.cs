using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    float originalSpeed = 0.01f;
    float speed;
    // Start is called before the first frame update
    public int jumpForce = 3;
    public Rigidbody rb;

    public bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Sol")){
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("Sol")){
            isGrounded = false;
        }
    }
    void Update()
    {   
        
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.forward * speed);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.back * speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.up,-2);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up,2);
        }
        
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = originalSpeed*2;
            }
        else{
            speed = originalSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up* 10,ForceMode.Impulse);
        }
    }
}
