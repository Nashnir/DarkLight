using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestPlayerCtroller : MonoBehaviour
{
    CharacterController myCharacterController;
    public float moveSpd;
    public float moveH, moveV;
    Animator myAnimator;
    public GameObject effect1;
    public GameObject effect2;

    // Use this for initialization
    void Start()
    {

        myCharacterController = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();
    }
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {

        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        if (moveV != 0 || moveH != 0)
        {
            myAnimator.SetBool("isRun", true);

            Vector3 movement = new Vector3(moveH, 0, moveV);
            Quaternion rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            Vector3 dir = rotation * movement;

            myCharacterController.SimpleMove(dir * moveSpd);
            if (!(Mathf.Abs(moveH) < 0.5 && Mathf.Abs(moveV) < 0.5))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 0.7f);
            }
        }
        else
        {
            myAnimator.SetBool("isRun", false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            myAnimator.SetTrigger("skill1");
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            myAnimator.SetTrigger("skill2");
        }

        
    }

    void MySkill1()
    {
        Instantiate(effect1, transform.position, Quaternion.identity);
       
        Collider[] colliders1 = Physics.OverlapSphere(transform.position, 3, 1<<LayerMask.NameToLayer("Monster"));
        if (colliders1.Length <= 0) return; 

        GameObject.Destroy(colliders1[0].gameObject);
    }

    void MySkill2()
    {

        Instantiate(effect2, transform.position, Quaternion.identity);

        Collider[] colliders2 = Physics.OverlapSphere(transform.position, 6, 1<<LayerMask.NameToLayer("Monster"));
        if (colliders2.Length <= 0) return;
        for (int i = 0; i < colliders2.Length; i++)
        {
            Debug.Log(colliders2[i].name);
            GameObject.Destroy(colliders2[i].gameObject);           
        }
    }
}
