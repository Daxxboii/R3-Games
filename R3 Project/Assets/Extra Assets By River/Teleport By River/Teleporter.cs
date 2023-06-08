using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class Teleporter : MonoBehaviour
{
    [Tag] public string PlayerTag;
    public Transform PlayerSpawnPointOnStart;

    private GameObject[] GameObjectsWithTagPlayer;
    [Scene]public string SceneToTeleportIndex, CurrentSceneIndex;





    void Start()
    {
        GameObjectsWithTagPlayer = GameObject.FindGameObjectsWithTag("Player");

        if(GameObjectsWithTagPlayer.Length>0){
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
            Fader._Fader.FadeOut(SceneToTeleportIndex, CurrentSceneIndex);
            this.enabled = false;
        }
    }

}
