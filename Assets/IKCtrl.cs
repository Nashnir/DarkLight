using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKCtrl : MonoBehaviour {
    public Animator myAnimator;
    public bool isActive = false;
    public Transform  lookObj;
    public Transform rightHandObj;
    public Transform rightFoot;
    public Transform leftFoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rightHandObj.Rotate(Vector3.forward*100);

	}
    private void OnAnimatorIK(int layerIndex)
    {
        if (myAnimator)
        {
            if (lookObj)
            {
                myAnimator.SetLookAtWeight(1);
                myAnimator.SetLookAtPosition(lookObj.position);
            }
            if (myAnimator)
            {
                myAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                myAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                myAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                myAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                myAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                myAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                myAnimator.SetIKPosition(AvatarIKGoal.RightFoot, rightFoot.position);
                myAnimator.SetIKRotation(AvatarIKGoal.RightFoot, rightFoot.rotation);

                myAnimator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                myAnimator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                myAnimator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFoot.position);
                myAnimator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFoot.rotation);
            }
        }
        else
        {
            myAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            myAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            myAnimator.SetLookAtWeight(0);
        }
    }
}