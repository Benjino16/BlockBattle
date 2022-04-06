using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Weapon mainGun;
    [SerializeField] Weapon leftGun;
    [SerializeField] Weapon rightGun;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && mainGun != null)
        {
            mainGun.Use();
        }
        if(Input.GetKey(KeyCode.Mouse0) && leftGun != null)
        {
            leftGun.Use();
        }
        if(Input.GetKey(KeyCode.Mouse1) && rightGun != null)
        {
            rightGun.Use();
        }
    }


}
