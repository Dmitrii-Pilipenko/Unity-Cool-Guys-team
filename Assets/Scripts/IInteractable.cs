using UnityEngine;

public interface IInteractable
{
    void OnGrab(Transform holdPoint);
    void OnDrop();
    Transform GetTransform();
}
