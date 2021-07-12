using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_03_Story_01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("The heat in the dessert is intolerable and the boy hopes that he finds some water soon.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
