using System;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public static event Action call;
    public static event Action endCall;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // creer une condition qui lance le trigger x temps apres que le jeux ai commencer
        {
            Triggercall();
        }
        if (Input.GetKeyDown(KeyCode.V)) // creer un script pour les dialogues npc quand le bouton de fin est presser par le player, ce script informera le manager qui lui informera phoneCall de lancer la fonction EndCall
        {
            TriggerEndCall();
        }
    }

    private void Triggercall()
    {
        if (call != null)
        {
            Debug.Log("Manager a declencher un appel");
            call.Invoke(); 
        }
    }
    private void TriggerEndCall()
    {
        
        if (endCall != null)
        {
            Debug.Log("Manager a finit un appel");
            endCall.Invoke();
            
        }
    }


}


