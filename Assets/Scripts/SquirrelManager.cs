using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelManager : MonoBehaviour
{

    public static SquirrelManager instance;

    private Player[] squirrels;

    private Transform squirrelCamera;

    private int currentSquirrel;

    private void Awake()
    {
        if(instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        
        squirrels = GameObject.FindObjectsOfType<Player>();

        squirrelCamera = Camera.main.transform;

                    //might be PlayerID??
        for(int i = 0; i< squirrels.Length; i++) {
            squirrels[i].playerID = i;
        }

        NextSquirrel();
    }

    public bool IsMyTurn(int i)
    {
        return i == currentSquirrel;
    }

    public void NextSquirrel() {
        StartCoroutine(_NextSquirrel());
    }

    public IEnumerator _NextSquirrel() {
        int nextSquirrel = currentSquirrel + 1;
        currentSquirrel -= 1;

        yield return new WaitForSeconds(2f);

        currentSquirrel = nextSquirrel;

        if(currentSquirrel >= squirrels.Length)
            currentSquirrel = 0;

        squirrelCamera.SetParent(squirrels[currentSquirrel].transform);
        squirrelCamera.localPosition = Vector3.zero + Vector3.back * 10f;
    }

}
