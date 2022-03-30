using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField] Lightning lightning;
    [SerializeField] float strikeSpeed;

    [SerializeField] GameObject attacker;

    float waitingTime = 0f;

    private void Update()
    {
        waitingTime += Time.deltaTime;
    }

    public void Strike(Vector2 target)
    {
        if (waitingTime > strikeSpeed)
        {
            Debug.Log("Spawned lightning at " + target);
            Lightning newLightning = Instantiate(lightning, target, new Quaternion(0, 0, 0, 0));
            newLightning.sender = attacker;

            waitingTime = 0f;
        }
    }
}
