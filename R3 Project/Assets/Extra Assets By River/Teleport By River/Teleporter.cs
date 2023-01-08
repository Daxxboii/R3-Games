using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class Teleporter : MonoBehaviour
{
    [Tooltip("SubScene Collection Index")]public int SceneToTeleportIndex,CurrentSceneIndex;
    [Tag] public string PlayerTag;
    public Transform PlayerSpawnPointOnStart;

    private GameObject[] GameObjectsWithTagPlayer;
    



    void Start()
    {
        GameObjectsWithTagPlayer = GameObject.FindGameObjectsWithTag("Player");

        if(GameObjectsWithTagPlayer[0] != null){
            GameObjectsWithTagPlayer[0].SetActive(false);
            GameObjectsWithTagPlayer[0].transform.position = PlayerSpawnPointOnStart.position;
            GameObjectsWithTagPlayer[0].SetActive(true);

        }


    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == PlayerTag)
        {
           // DontDestroyOnLoad(collision.gameObject);
            Fader._Fader.FadeOut(SceneToTeleportIndex,CurrentSceneIndex);
            this.enabled = false;
        }
    }

}
