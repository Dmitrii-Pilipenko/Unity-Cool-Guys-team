using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private List<IControllable> registry = new List<IControllable>();
    public void RegisterObject(IControllable obj)
    {
        if (!registry.Contains(obj))
        {
            registry.Add(obj);
        }
    }
    public void UnregisterObject(IControllable obj)
    {
        if (registry.Contains(obj))
        {
            registry.Remove(obj);
        }
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        bool isShiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        foreach (IControllable obj in registry)
        {
            obj.Move(h, v);

            if (isJumping)
            {
                obj.Jump();
            }
            if (isShiftPressed)
            {
                obj.ToggleGravity();
            }
        }
    }
}