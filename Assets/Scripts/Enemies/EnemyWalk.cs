using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] float maxspeed;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float speedMultiplier;
    [SerializeField] float drag;
    [SerializeField] float gravityMultiplier;
    [SerializeField] float airSpeed;
    [SerializeField] float airDrag;
    [SerializeField] GameObject walkRadius;
    GetPlayerPos getPlayer;
    bool foundplayer;
    [SerializeField] float Height = 2f;
    Vector3 movedirection;
    Vector3 slopeMoveDirection;
    RaycastHit slopeHit;
    Rigidbody rb;
    bool isGrounded;
    void Start()
    {
        getPlayer = walkRadius.GetComponent<GetPlayerPos>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        foundplayer = getPlayer.ReturnFoundPlayer();
        movedirection = getPlayer.ReturnDir();
        slopeMoveDirection = Vector3.ProjectOnPlane(movedirection, slopeHit.normal);
        //if (movedirection.magnitude <= Height || foundplayer == false)
        //{
            //rb.velocity = 0f * movedirection;
        //}
        //if (movedirection.magnitude + 0.1 <= Height && foundplayer == false)
        //{
        //    rb.velocity = 0f * movedirection;
        //}
        //if (movedirection.magnitude >= Height)
        //{
            rb.AddForce(movedirection.normalized * speed * speedMultiplier, ForceMode.VelocityChange);
            if (rb.velocity.magnitude > maxspeed)
            {
                rb.AddForce(rb.velocity * (-1) * speedMultiplier * 0.5f, ForceMode.VelocityChange);
            }
        //}
        
        
    }
    bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, Height / 2 + 0.1f))
        {
            if(slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    
    void ControlDrag()
    {
        if(isGrounded)
        {
            rb.drag = drag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
