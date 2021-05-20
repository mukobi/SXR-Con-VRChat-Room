/*
//Script by Child of the beast
//V 1.0
//https://github.com/ChildoftheBeast/VRC-UdonSharp-Scripts
*/
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using System.Collections;

public class BeerPong : UdonSharpBehaviour
{
    public GameObject ParentOfCups;
    public GameObject Ball;
    [UdonSynced]private int Cup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == ParentOfCups.transform) 
        {
            //Cup = other.transform.GetSiblingIndex();
            //SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "DespawnCup");
            other.gameObject.SetActive(false);
        }
    }

    public GameObject BallSpawn;
    private Vector3 Ball_Spawn;

    private void Start()
    {
        Ball_Spawn = BallSpawn.transform.position;
    }

    public void RespawnBall()
    {
        Networking.SetOwner(Networking.LocalPlayer, Ball);
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.position = Ball_Spawn;
    }
    public void Network_RespawnCups()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "RespawnCups");
    }
    public void RespawnCups()
    {
        int cups = ParentOfCups.transform.childCount;
        for (int v = 0; v < cups; v++)
        {
            ParentOfCups.transform.GetChild(v).gameObject.SetActive(true);
        }
    }
    public void DespawnCup()
    {
        ParentOfCups.transform.GetChild(Cup).gameObject.SetActive(false);
    }
}