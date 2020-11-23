using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using System.Collections;

namespace Com.GIMM.FinalFightasy
{
    public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        #region Private Fields

        private string whichPlayer;

        #endregion

        #region Public Fields

        [Tooltip("The current Health of our player")]
        public int Health = 1000;

        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;

        [Tooltip("The Player's UI GameObject Prefab")]
        [SerializeField]
        public GameObject PlayerUiPrefab;

        #endregion

        #region IPunObservable implementation

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(Health);
            }
            else
            {
                this.Health = (int)stream.ReceiveNext();
            }
        }

        #endregion

        #region MonoBehaviour CallBacks

        void Awake()
        {
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }

            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            if (PlayerUiPrefab != null)
            {
                GameObject _uiGo = Instantiate(PlayerUiPrefab);
                _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
            }
            else
            {
                Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
            }
        }

        void Update()
        {
            //Debug.Log("Player 1 Health: " + Health);
            //Debug.Log("Player 2 Health: " + Health);

            if (Health <= 0f)
            {
                //GameManager.Instance.LeaveRoom();
                Debug.Log("Dead");
            }
        }

        void CalledOnLevelWasLoaded()
        {
            GameObject _uiGo = Instantiate(this.PlayerUiPrefab);
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
        }

        #endregion
    }
}