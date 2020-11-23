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

        private string whichPlayer;

        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                whichPlayer = "1";
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                whichPlayer = "2";
            }

            animator = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();

            if (!animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }

        void Update()
        {
            if (!photonView.IsMine && PhotonNetwork.IsConnected)
            {
                return;
            }
            else if (photonView.IsMine && PhotonNetwork.IsConnected)
            {
                if (!animator)
                {
                    return;
                }
                else
                {
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

                        if (GameManager.Instance.distance < 50)
                        {
                            if (whichPlayer == "1")
                            {
                                GameManager.Instance.player2Health = GameManager.Instance.player2Health - 10;
                            }
                            else
                            {
                                GameManager.Instance.player1Health = GameManager.Instance.player1Health - 10;
                            }
                        }
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

                        if (GameManager.Instance.distance < 3)
                        {
                            if (whichPlayer == "1")
                            {
                                GameManager.Instance.player2Health = GameManager.Instance.player2Health - 15;
                            }
                            else
                            {
                                GameManager.Instance.player1Health = GameManager.Instance.player1Health - 15;
                            }
                        }
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

                        if (GameManager.Instance.distance < 3)
                        {
                            if (whichPlayer == "1")
                            {
                                GameManager.Instance.player2Health = GameManager.Instance.player2Health - 20;
                            }
                            else
                            {
                                GameManager.Instance.player1Health = GameManager.Instance.player1Health - 20;
                            }
                        }
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
            }
        }

        #endregion
    }
}