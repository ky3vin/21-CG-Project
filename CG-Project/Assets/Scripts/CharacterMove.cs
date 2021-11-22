using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Version 1. Camera follow target object.*/
public class CharacterMove : MonoBehaviour
{
    public float speed = 7f;
    public float jumpPower = 5f;
    public float rotateSpeed = 0.75f;
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    Vector3 movement;
    float h, v;
    bool isJumping;
    
    void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            m_Animator.SetBool("isJumping", true);
        }
        
        movement = new Vector3(h,0,v).normalized;
        transform.position += movement * speed * Time.deltaTime;
        m_Animator.SetBool("isWalking", movement!= Vector3.zero);

        transform.LookAt(transform.position + movement);
    }
    void FixedUpdate()
    {
       
        //Jump
        if (isJumping) {
            //rigidbody.MovePosition(transform.position + Vector3.up);
            GetComponent<Rigidbody>().AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
            isJumping = false;
            m_Animator.SetBool("isJumping", false);
        }
    }

    void AnimationUpdate()
    {
        if (h == 0 && v == 0)
        {
            m_Animator.SetBool("isWalking", false);
        }
        else { m_Animator.SetBool("isWalking", true); }
    }

}

