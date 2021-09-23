using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks
{
    public GameObject[] playerRoles;
    public Transform positionOne, positionTwo;
    public static GameController _instance;
    public GameObject readyButton;

    private bool gameover;
    private GameObject player;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        PhotonNetwork.AutomaticallySyncScene = true;
    }


    private void Start()
    {
        player = PhotonNetwork.Instantiate("HatPerson", positionOne.position, Quaternion.identity, 0);
        // else
        //     player02 = PhotonNetwork.Instantiate("HatPerson", positionTwo.position, Quaternion.identity, 0);
    }

    public void GameOver(int playerIndex)
    {
        if (gameover == false)
        {
            ScoreController._instance.addScore(playerIndex);
            gameover = true;
            StartCoroutine(Over());
        }

    }

    private void CreatePlayers()
    {

        player = PhotonNetwork.Instantiate("HatPerson", positionOne.position, Quaternion.identity, 0);
    }

    IEnumerator Over()
    {
        yield return new WaitForSeconds(1);
        ScoreUI._instance.ShowUI();

        yield return new WaitForSeconds(1);
        gameover = false;
        //SceneManager.LoadScene(1);
        PhotonNetwork.LoadLevel(1);
        print("ReLoad");

        if (player == null)
            CreatePlayers();
    }
}
