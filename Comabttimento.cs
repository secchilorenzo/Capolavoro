using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comabttimento : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D hitbox;

    private void Start()
    {
        hitbox = transform.Find("Spadone").GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) { 
            Attacco();
            Invoke("attiva", 0.2f); 
            Invoke("disattiva", 0.4f);
        }
    }

    void Attacco()
    {
        animator.SetTrigger("Attack");
    }

    void attiva()
    {
        hitbox.gameObject.SetActive(true);
    }

    void disattiva()
    {
        hitbox.gameObject.SetActive(false);
    }
}
