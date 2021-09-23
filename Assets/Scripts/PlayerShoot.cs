using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShoot : MonoBehaviour
{
    public KeyCode shootKey;
    public GameObject bulletPrefab;
    public Transform shootPosTrans;

    private PhotonView playerPhotonView;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        playerPhotonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!playerPhotonView.IsMine && PhotonNetwork.IsConnected)
            return;
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(shootKey))
        {
            PhotonNetwork.Instantiate(bulletPrefab.name, shootPosTrans.position, transform.rotation);
        }
    }
}
