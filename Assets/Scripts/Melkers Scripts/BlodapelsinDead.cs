using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Melker
public class BlodapelsinDead : MonoBehaviour
{
    //Den h�r koden anv�nds

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Die");
    }
}
