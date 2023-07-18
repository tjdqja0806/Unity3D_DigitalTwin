using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuCircle[] script = null;

    private int current;

    void Awake() { current = 0; }

    void Update()
    {
        //GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            script[current].ChangeTarget(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            script[current].ChangeTarget(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ChangeCurrent(-1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ChangeCurrent(1);
        }
    }

    private void ChangeCurrent(int offset)
    {
        current += offset;
        if (current > script.Length - 1) current = 0;
        else if (current < 0) current = script.Length - 1;
    }

    public void Left(int num) { script[num].ChangeTarget(-1); }

    public void Right(int num) { script[num].ChangeTarget(1); }
}