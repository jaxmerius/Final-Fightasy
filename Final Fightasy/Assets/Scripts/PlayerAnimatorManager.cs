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
        private float playerSpeed = 2.0f;

        #endregion

        #region MonoBehaviour Callbacks

        private Animator animator;

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

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }

        #endregion
    }
}