using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_01_Story_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("He jumps over abysses with the roaring sea under his feet \n full of dangerous fish.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
