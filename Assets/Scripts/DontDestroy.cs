using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("BGM").Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}