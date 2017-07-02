using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public GameObject Hero;
    CharacterController chraracterScript;
    Transform heroTransform;
    float horizontal, vertical;
    Vector2 smoothV;
    Vector2 mouseLook;
    float smoothing = 2f;
    float sensitivity = 5f;




    private void Start()
    {
        chraracterScript = Hero.GetComponent<CharacterController>();
        heroTransform = Hero.transform;
    }


    private void Update()
    {
        Look();
    }


    private void Look()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        var md = Vector2.Scale(new Vector2(horizontal, vertical), new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y,-25f,7f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        heroTransform.localRotation = Quaternion.AngleAxis(mouseLook.x, heroTransform.up);

      
    }

    void LateUpdate()
    {


    }

}
