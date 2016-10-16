using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

    private Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D (Collider2D collider) {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();

        if (attacker) {
            anim.SetTrigger("underAttackTrigger"); 
        }
    }
}
