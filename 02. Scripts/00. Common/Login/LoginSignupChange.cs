using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSignupChange : MonoBehaviour
{
    public GameObject login;
    public GameObject signUp;

    private bool isSignUp;

    public void Change()
    {
        isSignUp = !isSignUp;
        login.SetActive(!isSignUp);
        signUp.SetActive(isSignUp);
    }
}
