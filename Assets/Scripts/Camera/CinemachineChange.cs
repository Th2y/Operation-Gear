using UnityEngine;

public class CinemachineChange : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void MudarCam(string cam)
    {
        animator.Play("Camera"+ cam);
    }
}
