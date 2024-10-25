using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class joystickMove222 : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image joystickBackground;
    private Image joystickHandle;
    private Vector2 inputVector;

    // Joystick movement radius
    public float movementRadius = 100f;

    void Start()
    {
        // Get references to joystick components
        joystickBackground = GetComponent<Image>();
        joystickHandle = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); // Trigger drag on pointer down to start moving the joystick
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pointerPosition);

        // Normalize joystick handle movement within the specified radius
        pointerPosition = Vector2.ClampMagnitude(pointerPosition, movementRadius);

        // Move the joystick handle
        joystickHandle.rectTransform.anchoredPosition = pointerPosition;

        // Convert the joystick position to a normalized vector for controlling player movement
        inputVector = new Vector2(pointerPosition.x / movementRadius, pointerPosition.y / movementRadius);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset joystick handle position when released
        inputVector = Vector2.zero;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
    }

    // Method to get the horizontal value of the joystick
    public float Horizontal()
    {
        return inputVector.x;
    }

    // Method to get the vertical value of the joystick
    public float Vertical()
    {
        return inputVector.y;
    }
}


