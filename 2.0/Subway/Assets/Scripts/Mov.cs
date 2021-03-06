using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Mov : MonoBehaviour
{

    private CharacterController _characterController;
    private Vector3 moveVec, gravity;

    public GameObject scr;

    public float speed, jumpSpeed;
    public Animator anim;
    private int laneNumber = 1,
        lanesCount = 2;

    public float firstsLanePos,
        laneDistance,
        sideSpeed;
        
    bool but = true;
    
    void Start()
    {
        
        _characterController = GetComponent<CharacterController>();
     
        gravity = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    public void  OnTriggerEnter (Collider collision)
    {
         
     //   gameObject.SetActive(false);
        //   SceneManager.LoadScene(0);
     
    }
    void Update()
    {
       
        if (_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("slide", true);
                Invoke("a", 0.9f);
            }
            gravity = Vector3.zero;
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                gravity.y = jumpSpeed;
                anim.SetBool("inAir", true);
                StartCoroutine(o());
            }

           
        }
        
        else
        {
            gravity += Physics.gravity *Time.deltaTime *  3;
          //  anim.SetBool("inAir", false);
        }


      //  moveVec.x = speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;
       // moveVec += gravity;
        float input = Input.GetAxis("Horizontal");


        if (Mathf.Abs(input) > .2f)
        {
            if (but)
            {


                but = false;

                laneNumber += (int)Mathf.Sign(input);
             //   Debug.Log(laneNumber);
                laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
             //   Debug.Log(laneNumber);
                //   Debug.Log(laneNumber);
            }

            

        }
        else
        {
            but = true;
        }
        _characterController.Move(moveVec);
        Vector3 newPos = transform.position;
       //s Debug.Log(laneNumber * laneDistance);
        newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);


        transform.position = newPos;
    }
    public IEnumerator o()
    {
        yield return new WaitForSeconds((float)0.85f);
        anim.SetBool("inAir", false);
    }
    public void a()
    {
      
        anim.SetBool("slide", false);
    }

}


