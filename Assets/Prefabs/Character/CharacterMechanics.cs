using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float jumpPower;

    private float gravityForce;
    private Vector3 moveVector;

    private CharacterController charController;
    private Animator charAnimator;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        charAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        CharacterMove();
        GamingGravity();
    }

    private void CharacterMove()
    {
        if (charController.isGrounded)
        {
            moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * speedMove;
            moveVector.z = Input.GetAxis("Vertical") * speedMove;

            if (moveVector.x != 0 || moveVector.z != 0)
                charAnimator.SetBool("Move", true);
            else
                charAnimator.SetBool("Move", false);

            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        }
        moveVector.y = gravityForce;
        charController.Move(moveVector * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!charController.isGrounded)
            gravityForce -= 20f * Time.deltaTime;
        else
            gravityForce = -1f;

        if (Input.GetKeyDown(KeyCode.Space) && charController.isGrounded)
            gravityForce = jumpPower;
    }
}
