using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] TextMesh textMesh;

    [SerializeField] float startSpeed = 12f;
    [SerializeField] float speedDrag = .0f;
    [SerializeField] float timeAfterDisappear = 2f;
    [SerializeField] int disappearSpeed = 1;
    [SerializeField] int appearSpeed = 1;

    float currentSpeed;
    int fontSizeSave;
    bool disappear = false;
    Vector3 randomDirection;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();

        currentSpeed = startSpeed;
        fontSizeSave = textMesh.fontSize;
        textMesh.fontSize = 0;
        randomDirection = DirectionRandomizer();
    }

    private void Start()
    {
        StartCoroutine(DisappearTimer());
    }

    private Vector3 DirectionRandomizer()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, 0);
    }

    private void Update()
    {
        if(textMesh.fontSize < fontSizeSave && !disappear)
        {
            textMesh.fontSize += appearSpeed;
        }
        if(disappear)
        {
            GetComponent<TextMesh>().fontSize -= disappearSpeed;
        }
        if(currentSpeed > 0f)
        {
            currentSpeed -= speedDrag;
        }

        transform.position += (randomDirection + transform.up) * currentSpeed * Time.deltaTime;

        if(textMesh.fontSize <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DisappearTimer()
    {
        yield return new WaitForSeconds(timeAfterDisappear);
        disappear = true;

    }
}
