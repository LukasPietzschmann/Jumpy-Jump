using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_02_Story_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("He jumps over gigantic mushrooms and over big stones. He rests in a tent with a campfire to keep the monsters away.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
