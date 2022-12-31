using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class Teleporter : MonoBehaviour
{
    [Scene] public string SceneToTeleport;
    [Tag] public string PlayerTag;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == PlayerTag)
        {
           // DontDestroyOnLoad(collision.gameObject);
            Fader._Fader.FadeOut(SceneToTeleport);
            this.enabled = false;
        }
    }

}
