﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Gameplay_Level1");
    }
}
