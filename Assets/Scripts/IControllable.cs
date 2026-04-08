using UnityEngine;

public interface IControllable
{
    void Move(float horizontal, float vertical) { }
    void Jump();
    void ToggleGravity();
    // void Interact();
    //взаимодействие (взять может) на будущее, пока так ))
}
