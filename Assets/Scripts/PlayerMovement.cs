using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMovement : MonoBehaviourPun
{
    protected Rigidbody rigid;
    protected float inputHorizontal;
    protected float inputVertical;
    protected Vector3 movement;
    protected Quaternion rotatement;
    protected PhotonView playerPhotonView;

    public float moveSpeed = 4;
    public float rotateSpeed = 80;
    public GameObject boomEffectPrefab;
    public int playerIndex;
    public Text nameText;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        playerPhotonView = GetComponent<PhotonView>();

        DontDestroyOnLoad(transform.gameObject);

        if (playerPhotonView.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
        }
        else
        {
            nameText.text = playerPhotonView.Owner.NickName;
            nameText.color = new Color(255, 6, 0, 255);
        }
    }

    protected void Start()
    {
        rigid = GetComponent<Rigidbody>();
        movement = new Vector3();
    }

    protected virtual void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!playerPhotonView.IsMine && PhotonNetwork.IsConnected)
            return;
        movement.Set(inputHorizontal, 0, inputVertical);

        rigid.velocity = movement.normalized * moveSpeed;

        if (inputVertical != 0 || inputHorizontal != 0)
        {
            rotatement = Quaternion.LookRotation(movement);
            rigid.rotation = Quaternion.RotateTowards(transform.rotation, rotatement, rotateSpeed);
        }
        else
        {
            //当没有输入时，将Player角速度设为0
            rigid.angularVelocity = Vector3.zero;
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
        Instantiate(boomEffectPrefab, transform.position, Quaternion.identity);
        CameraShake._instance.PlayerShakeCamera();
        GameController._instance.GameOver(playerIndex);
    }
}
