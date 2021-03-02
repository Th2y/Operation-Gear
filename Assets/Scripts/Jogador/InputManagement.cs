using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagement : MonoBehaviour
{
    private JogadorMovimentacao jogadorMovimentacao;

    private void Awake()
    {
        jogadorMovimentacao = new JogadorMovimentacao();
    }

    private void OnEnable()
    {
        jogadorMovimentacao.Enable();
    }

    private void OnDisable()
    {
        jogadorMovimentacao.Disable();
    }

    private void Start()
    {
        jogadorMovimentacao.Touch.TouchPress.started += ctx => StartTouch(ctx);
        jogadorMovimentacao.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + jogadorMovimentacao.Touch.TouchPosition.ReadValue<Vector2>());
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended " + context.ReadValue<float>());
    }
}
