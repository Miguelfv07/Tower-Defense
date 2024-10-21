using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
public static BuildManager instance;
    private void Awake()
    {
        instance = this;
    }
}
