using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spirit.Chan
{

    public class Character : MonoBehaviour
    {
        private Animator animator = null;
        private Rigidbody body = null;
        private Transform ts = null;

        private Vector3 moveVelo = Vector3.zero;

        [SerializeField] [Range(1, 5)] private int moveSpeed = 1;
        [SerializeField] [Range(1, 5)] private int mouseXSpeed = 1;

        [SerializeField] private PlayerCamera playerCamera = null;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            body = GetComponent<Rigidbody>();
            ts = transform;
        }

        private void FixedUpdate()
        {
            moveVelo = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (Input.GetKey(Manager.Data.gameData.SprintKey) ? moveSpeed * 2 : moveSpeed);
            //ts.Translate(moveVelo * Time.fixedUnscaledDeltaTime, Space.Self);
            body.velocity = moveVelo;
            animator.SetFloat("MoveSpeed", moveVelo.z);
            animator.SetFloat("MoveDirection", moveVelo.x);
        }
        private void Update()
        {
            if (Input.GetKeyDown(Manager.Data.gameData.JumpKey) && !animator.GetBool("IsJump")) animator.SetTrigger("Jump");
            if (Input.GetKeyDown(Manager.Data.gameData.ViewSwapKey)) playerCamera.SetCameraView(!Manager.Data.gameData.isFirstView);
        }
    }

}