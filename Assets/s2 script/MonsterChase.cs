using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public Rigidbody monsterRigid;
    public Transform monsterTrans, playerTrans;
    public int monsterSpeed;

    void FixedUpdate()
    {
        monsterRigid.velocity = transform.forward * monsterSpeed * Time.deltaTime; 
    }

    void Update()
    {
        monsterTrans.LookAt(playerTrans);
    }

}
