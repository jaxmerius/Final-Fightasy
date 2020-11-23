using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.EventSystems;

namespace Com.GIMM.FinalFightasy
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region Private Fields

        private string character;
        private GameObject player1;
        private GameObject player2;
        private bool isPlayer1 = false;
        private bool isPlayer2 = false;
        private PlayerManager player1Mananger;
        private PlayerManager player2Mananger;

        #endregion

        #region Public Fields

        public static GameManager Instance;

        [Tooltip("These prefabs are used for representing the player")]
        public GameObject barbarianPrefab;
        public GameObject witchPrefab;
        public float distance;
        public int player1Health = 1000;
        public int player2Health = 1000;
        public GameObject newPlayer;

        #endregion

        #region Photon Callbacks

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName);

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
                LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
                LoadArena();
            }
        }
        #endregion

        #region Public Methods

        void Start()
        {
            Instance = this;
        }

        void Update()
        {
            if (isPlayer1 == true && isPlayer2 == true)
            {
                distance = Vector3.Distance(player1.transform.position, player2.transform.position);
                Debug.Log("Distance: " + distance);

                Debug.Log("Player 1 Health GameManager: " + player1Health);
                Debug.Log("Player 2 Health GameManager: " + player2Health);

                player1Mananger.Health = player1Health;
                player2Mananger.Health = player2Health;
            }
            else if (isPlayer1 == true)
            {
                Debug.Log("Player 1 Health GameManager: " + player1Health);
                player1Mananger.Health = player1Health;
            }

            //Debug.Log(player1);
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void CharacterSelected()
        {
            character = EventSystem.current.currentSelectedGameObject.name;

            if (barbarianPrefab == null || witchPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if (PlayerManager.LocalPlayerInstance == null && character == "barbarian")
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
                    {
                        PhotonNetwork.Instantiate(this.barbarianPrefab.name, new Vector3(-4f, 0f, 0f), Quaternion.Euler(0, 90, 0), 0);
                        newPlayer = GameObject.Find("Barbarian(Clone)");
                        newPlayer.name = "Player1";
                        player1 = GameObject.Find("Player1");
                        isPlayer1 = true;
                        Debug.Log(isPlayer1);
                        player1Mananger = player1.GetComponent<PlayerManager>();
                    }
                    else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
                    {
                        PhotonNetwork.Instantiate(this.barbarianPrefab.name, new Vector3(4f, 0f, 0f), Quaternion.Euler(0, -90, 0), 0);
                        newPlayer = GameObject.Find("Barbarian(Clone)");
                        newPlayer.name = "Player2";
                        player2 = GameObject.Find("Player2");
                        player2Mananger = player2.GetComponent<PlayerManager>();
                    }
                }
                else if (PlayerManager.LocalPlayerInstance == null && character == "witch")
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
                    {
                        PhotonNetwork.Instantiate(this.witchPrefab.name, new Vector3(-4f, 0f, 0f), Quaternion.Euler(0, 90, 0), 0);
                        newPlayer = GameObject.Find("Witch(Clone)");
                        newPlayer.name = "Player1";
                        player1 = GameObject.Find("Player1");
                        player1Mananger = player1.GetComponent<PlayerManager>();
                    }
                    else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
                    {
                        PhotonNetwork.Instantiate(this.witchPrefab.name, new Vector3(4f, 0f, 0f), Quaternion.Euler(0, -90, 0), 0);
                        newPlayer = GameObject.Find("Witch(Clone)");
                        newPlayer.name = "Player2";
                        player2 = GameObject.Find("Player2");
                        player2Mananger = player2.GetComponent<PlayerManager>();
                    }
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
        }

        #endregion

        #region Private Methods

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        #endregion
    }
}