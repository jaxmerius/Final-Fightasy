using UnityEngine;
using System.Collections;
using Photon.Pun;

namespace Com.GIMM.FinalFightasy
{
    public class PlayerAnimatorManager : MonoBehaviourPun
    {
        #region Private Fields

        [SerializeField]
        private float directionDampTime = 0.25f;

        private CharacterController controller;
        private Animator animator;
        private float playerSpeed = 2.0f;

        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            animator = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();

            if (!animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }

        void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }

            if (!animator)
            {
                return;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                animator.ResetTrigger("Idle");
                animator.SetTrigger("Walk");
                animator.ResetTrigger("Jab");
                animator.ResetTrigger("Special");
                animator.ResetTrigger("Charge");
                animator.ResetTrigger("Power");
                animator.ResetTrigger("Guard");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("Walk");
                animator.SetTrigger("Jab");
                animator.ResetTrigger("Special");
                animator.ResetTrigger("Charge");
                animator.ResetTrigger("Power");
                animator.ResetTrigger("Guard");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("Walk");
                animator.ResetTrigger("Jab");
                animator.SetTrigger("Special");
                animator.ResetTrigger("Charge");
                animator.ResetTrigger("Power");
                animator.ResetTrigger("Guard");
            }
            else if (Input.GetKey(KeyCode.L))
            {
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("Walk");
                animator.ResetTrigger("Jab");
                animator.ResetTrigger("Special");
                animator.SetTrigger("Charge");
                animator.ResetTrigger("Power");
                animator.ResetTrigger("Guard");
            }
            else if (Input.GetKeyUp(KeyCode.L))
            {
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("Walk");
                animator.ResetTrigger("Jab");
                animator.ResetTrigger("Special");
                animator.ResetTrigger("Charge");
                animator.SetTrigger("Power");
                animator.ResetTrigger("Guard");
            }
            else if (Input.GetKey(KeyCode.E))
            {
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("Walk");
                animator.ResetTrigger("Jab");
                animator.ResetTrigger("Special");
                animator.ResetTrigger("Charge");
                animator.ResetTrigger("Power");
                animator.SetTrigger("Guard");
            }
            else
            {
                animator.SetTrigger("Idle");
                animator.ResetTrigger("Walk");
                animator.ResetTrigger("Jab");
                animator.ResetTrigger("Special");
                animator.ResetTrigger("Charge");
                animator.ResetTrigger("Power");
                animator.ResetTrigger("Guard");
            }

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }

        #endregion
    }
}