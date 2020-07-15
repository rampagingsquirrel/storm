using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class OnInstantiate : MonoBehaviour
{

    void Start()
    {
        // Find camera & set to follow player
        GameObject.FindWithTag("MainCamera").GetComponent<FollowPlayer>().SetTarget(gameObject, (gameObject.transform.position + new Vector3(0, -20, 0)));

        // Find background & set to follow player
        GameObject.FindWithTag("background").GetComponent<FollowPlayer>().SetTarget(gameObject, new Vector3(0, 500, 0));


    }
}
