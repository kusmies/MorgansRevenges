using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOUR_BG_SCRIPT : MonoBehaviour
{
    float parallaxEffectMultiplier = .99f;
    public GameObject player;
    Transform myTran;
    Transform playerTran;
    Vector3 lastPlayerPosition;

    private void Start()
    {
        playerTran = player.GetComponent<Transform>();
        myTran = GetComponent<Transform>();
        lastPlayerPosition = playerTran.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = playerTran.position - lastPlayerPosition;
        myTran.position += deltaMovement * parallaxEffectMultiplier;
        lastPlayerPosition = playerTran.position;
    }
}
