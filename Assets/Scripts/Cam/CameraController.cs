using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update() {
        var myPos = transform.position;
        Vector3 target = Vector3.MoveTowards(myPos, player.position, 40 * Time.deltaTime);
        transform.position = new Vector3(target.x, myPos.y, myPos.z);
    }
}
