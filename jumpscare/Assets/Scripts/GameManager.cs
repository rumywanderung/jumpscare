﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public AIManager aimanager;

    void Start()
    {
        aimanager = FindObjectOfType<AIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
