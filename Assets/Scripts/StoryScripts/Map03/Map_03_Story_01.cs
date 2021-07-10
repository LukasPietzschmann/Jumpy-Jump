using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_03_Story_01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("The Heat in the dessert is intolerable and the Boy hopes that he finds some water soon.");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
