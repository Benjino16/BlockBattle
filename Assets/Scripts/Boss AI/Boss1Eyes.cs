using System.Collections;
using UnityEngine;

public class Boss1Eyes : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] string animationName;

    void Start()
    {
        StartCoroutine(eyeTimer());
    }

    private void Blink()
    {
        animator.Play(animationName);
    }

    private float RandomBlinkTime()
    {
        return Random.Range(minTime, maxTime);
    }

    IEnumerator eyeTimer()
    {
        yield return new WaitForSeconds(RandomBlinkTime());
        Blink();
        StartCoroutine(eyeTimer());
    }
}
