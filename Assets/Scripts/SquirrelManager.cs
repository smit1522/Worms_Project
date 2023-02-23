using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelManager : MonoBehaviour
{

    public static SquirrelManager instance;

    private Squirrel[] squirrels;

    private Transform squirrelCamera;

    private int currentSquirrel;

    private void Awake()
    {
        if(instance != null)
            Destroy(this);
        else
            instance = this;
    }

    public bool IsMyTurn(int i)
    {
        return i == currentSquirrel;
    }



}
