using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCtroller : MonoBehaviour {
    //GameObject go;
    CharacterController myCharacterController;
    bool isMove;
    Vector3 moveDir = Vector3.zero;
    public float moveSpd;
    Rigidbody rig;
    public float moveH, moveV;
    Animator myAnimator;
    public GameObject effect;

	// Use this for initialization
	void Start () {
        //go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        myCharacterController = GetComponent<CharacterController>();
        isMove = false;
        rig = transform.GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
	}
    RaycastHit hit;
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButton(0))
        //{
        //    //Debug.Log(Input.mousePosition);
        //    //Vector3 vp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0.3f));
        //    //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    //go.transform.position = vp;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Debug.DrawLine(ray.origin, ray.direction);
        //    if (Physics.Raycast(ray, out hit,200,LayerMask.GetMask("Ground")))
        //    {
        //        //go.transform.position = hit.point;
        //        Instantiate(GameSetting.Instance.mousefxNormal, hit.point, Quaternion.identity);

        //        Vector3 targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        //        moveDir = targetPos - transform.position;
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.6f);
        //        //transform.LookAt(targetPos);
        //        transform.DOMove(hit.point, Vector3.Distance(transform.position,hit.point));
        //        isMove = true;              
        //    }                       
        //}
        //if (isMove)
        //{          
        //    //m_CharacterController.SimpleMove(moveDir.normalized * moveSpd * Time.deltaTime * 10);
        //    if (Vector3.Distance(transform.position, hit.point) <= 0.05f)
        //    {
        //        isMove = false;
        //    }
        //}

        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        if (moveV != 0 || moveH != 0)
        {
            myAnimator.SetBool("isWalk", true);

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
            myAnimator.SetBool("isWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            myAnimator.SetTrigger("skill1");
           
        }

        //--------------------------角色控制器--------------------------

        //myCharacterController.SimpleMove(transform.forward * moveV * moveSpd);
        //transform.Rotate(new Vector3(0, moveH * moveSpd, 0));


        //----------------------------刚体----------------------------
        //rig.MovePosition(transform.position + transform.forward * moveV * 0.3f);
        // rig.MoveRotation(transform.rotation * Quaternion.Euler(0, moveH*5, 0));
    }
    void MySkill1()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
