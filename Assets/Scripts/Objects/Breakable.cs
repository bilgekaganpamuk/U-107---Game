using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    [Header ("Break Effects")]
    public LootTable thisLoot;

    [Header ("Animations")]
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator> ();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name== "Down Hit Box")
        {
            Break();
        }
    }
    public void Break () {
        anim.SetBool ("isBroken", true);
        StartCoroutine (BreakCo ());
    
        if (gameObject.name == "Pot") {
            FindObjectOfType<AudioManager> ().Play ("Pot Breaking");
        }
        if (gameObject.name == "Bush") {
            FindObjectOfType<AudioManager> ().Play ("Bush Breaking");
        }
    }



    IEnumerator BreakCo () {
        yield return new WaitForSeconds (.3f);
        this.gameObject.SetActive (false);
    }
}