using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;

    public GameObject mainPlayer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }
    public GameObject GetPlayer()
    {
        return mainPlayer;
    }

    void Update()
    {

    }
}
