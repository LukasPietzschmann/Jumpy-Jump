using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_02_Story_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("He jumps over gigantic Mushrooms and over big stones. He rests in a Tent with a Campfire to keep the Monsters Away.");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
