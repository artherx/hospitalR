using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public Animator animator;
    public SkinnedMeshRenderer  skinnedMeshRenderer;
    public Transform[] avatar;
    public Transform avatarC;

    private void Update()
    {

        if (avatarC != null && avatar[0] != null && skinnedMeshRenderer != null)
        {
            avatarC.position = avatar[0].position + new Vector3(0, -skinnedMeshRenderer.bounds.size.y, 0);
            avatarC.rotation = avatar[0].rotation;
        }
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);

            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
            
            if (avatar[1] != null)
            {
                animator.SetIKPosition(AvatarIKGoal.RightHand, avatar[1].position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, avatar[1].rotation);
                
            }
            if (avatar[2] != null)
            {
                animator.SetIKPosition(AvatarIKGoal.LeftHand, avatar[2].position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, avatar[2].rotation);
                
            }
            if (avatar[3] != null)
            {
                animator.SetIKPosition(AvatarIKGoal.RightFoot, avatar[3].position);
                animator.SetIKRotation(AvatarIKGoal.RightFoot, avatar[3].rotation);
                
            }

            if (avatar[4] != null)
            {
                animator.SetIKPosition(AvatarIKGoal.LeftFoot, avatar[4].position);
                animator.SetIKRotation(AvatarIKGoal.LeftFoot, avatar[4].rotation);
                
            }
            else
            {
                Debug.Log("Avatar is null");
            }
        }
        else
            Debug.Log("Animator is null");
    }
}
