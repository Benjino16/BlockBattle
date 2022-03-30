using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    GameObject Player;

    [SerializeField] LightningController lightningController;

    [SerializeField] Animator boss1Animator;


    [SerializeField] float strikeCooldown;
    [SerializeField] float delayAfterAnimationStart;

    float strikeTimer;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        strikeTimer = strikeCooldown;
    }
    private void Update()
    {
        strikeTimer -= Time.deltaTime;
        if(strikeTimer < 0f)
        {
            LightningStrike();
            strikeTimer = strikeCooldown;
        }
    }

    
    private void LightningStrike()
    {
        if (Player != null)
        {
            StartCoroutine(ExampleCoroutine());
            boss1Animator.Play("Boss1_Loading_Animation");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(delayAfterAnimationStart);
        lightningController.Strike(GameObject.FindGameObjectWithTag("Player").transform.position);

    }
}
