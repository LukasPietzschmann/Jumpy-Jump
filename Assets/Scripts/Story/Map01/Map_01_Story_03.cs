using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_01_Story_03 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("On his journey through the world he avoids evil spiders and traps.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
