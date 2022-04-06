using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] bool right = true; //BEANS


    public virtual void Awake()
    {
        if(!right)
        {
            transform.localPosition = new Vector2(-transform.localPosition.x, transform.localPosition.y);
            transform.localRotation = new Quaternion(0, 180, -transform.localRotation.z, 0);
        }
    }
    public virtual void Use()
    {

    }
}
