using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update() {
        var myPos = transform.position;
        var playerPos = player.position;
        Vector3 target = Vector3.MoveTowards(myPos, new Vector3(playerPos.x, playerPos.y + 10, playerPos.z), 40 * Time.deltaTime);
        transform.position = new Vector3(target.x, target.y, myPos.z);
    }
}
