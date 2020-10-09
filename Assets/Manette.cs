using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Manette
{
    public bool isKeyboardandMouse;
    public Gamepad gp { get; set; }
    private Keyboard kb;
    private Mouse mouse;

    public Manette(Gamepad game)
    {

        isKeyboardandMouse = false;
        gp = game;
        kb = Keyboard.current;
        mouse = Mouse.current;

    }

    public Manette()
    {

        isKeyboardandMouse = true;
        kb = Keyboard.current;
        mouse = Mouse.current;
        gp = new Gamepad();

    }

    public Vector2 dpad
    {

        get
        {

            if (isKeyboardandMouse)
            {

                float x = 0, y = 0;
                if (kb.leftArrowKey.isPressed) x = -1;
                if (kb.rightArrowKey.isPressed) x = 1;
                if (kb.downArrowKey.isPressed) y = -1;
                if (kb.upArrowKey.isPressed) y = 1;
                return new Vector2(x,y);

            }
            else
            {

                return gp.dpad.ReadValue();

            }

        }
        
    }

    public ButtonControl aButton
    {

        get
        {

            if (isKeyboardandMouse) return KBControls.GetAButton(kb);
            return gp?.aButton;

        }
        
    }

    public ButtonControl bButton
    {

        get
        {

            if (isKeyboardandMouse) return KBControls.GetBButton(kb);
            return gp?.bButton;

        }
        
    }
    public ButtonControl xButton
    {

        get
        {

            if (isKeyboardandMouse) return KBControls.GetXButton(kb);
            return gp?.xButton;

        }
        
    }
    public ButtonControl yButton
    {

        get
        {

            if (isKeyboardandMouse) return KBControls.GetYButton(kb);
            return gp?.yButton;

        }
        
    }

    public ButtonControl buttonEast
    {
        
        get
        {

            if (isKeyboardandMouse) return KBControls.GetBButton(kb);
            return gp?.buttonEast;

        }
        
    }

    public ButtonControl buttonNorth
    {
        
        get
        {

            if (isKeyboardandMouse) return KBControls.GetYButton(kb);
            return gp?.buttonNorth;

        }
        
    }

    public ButtonControl buttonWest
    {
        
        get
        {

            if (isKeyboardandMouse) return KBControls.GetXButton(kb);
            return gp?.buttonWest;

        }
        
    }

    public ButtonControl buttonsouth
    {
        
        get
        {
            return isKeyboardandMouse ? KBControls.GetAButton(kb) : gp?.buttonSouth;
        }
        
    }

    public ButtonControl leftShoulder
    {
        
        get
        {
            return isKeyboardandMouse ? KBControls.GetLeftShoulder(kb) : gp.leftShoulder;
        }
        
    }

    public ButtonControl leftTrigger
    {

        get
        {
            return isKeyboardandMouse ? KBControls.GetLeftTrigger(mouse) : gp.leftTrigger;
        }
        
    }

    public ButtonControl rightShoulder
    {
        
        get
        {
            return isKeyboardandMouse ? KBControls.GetRightShoulder(kb) : gp.rightShoulder;
        }
        
    }

    public ButtonControl rightTrigger
    {
        
        get
        {
            return isKeyboardandMouse ? KBControls.GetRightTrigger(mouse) : gp.rightTrigger;
        }
        
    }

    public ButtonControl startButton
    {
        
        get
        {
            return isKeyboardandMouse ? KBControls.GetStartButton(kb) : gp?.startButton;
        }
        
    }

    public ButtonControl selectButton
    {
        
        get
        {
            return isKeyboardandMouse ? KBControls.GetSelectButton(kb) : gp?.selectButton;
        }
        
    }

    public ButtonControl joinButton
    {

        get { return isKeyboardandMouse ? KBControls.GetAButton(kb) : gp?.startButton; }
    }



    public Vector2 leftStick
    {

        get
        {
            
            if (isKeyboardandMouse)
            {

                float x = 0, y = 0;
                if (kb.aKey.isPressed) x = -1;
                if (kb.dKey.isPressed) x = 1;
                if (kb.sKey.isPressed) y = -1;
                if (kb.wKey.isPressed) y = 1;
                return new Vector2(x,y);

            }
            return gp.leftStick.ReadValue();

            }
        
    }

    public Vector2 rightStick
    {
        
        get
        {
            
            if (isKeyboardandMouse)
            {

                float x = 0, y = 0;
                if (kb.leftArrowKey.isPressed) x = -1;
                if (kb.rightArrowKey.isPressed) x = 1;
                if (kb.downArrowKey.isPressed) y = -1;
                if (kb.upArrowKey.isPressed) y = 1;
                return new Vector2(x,y);

            }
            return gp.rightStick.ReadValue(); 
            
        }
        
    }

    public Vector2 mousePosition
    {

        get { return mouse.position.ReadValue(); }

    }

    public Vector2 mouseDelta
    {

        get { return mouse.delta.ReadValue(); }

    }

    public ButtonControl leftClick
    {

        get { return mouse.leftButton; }

    }

    public ButtonControl rightClick
    {

        get { return mouse.rightButton; }

    }



}

public static class KBControls
{

    public static ButtonControl GetAButton(Keyboard kb)
    {

        return kb.spaceKey;

    }
    public static ButtonControl GetBButton(Keyboard kb)
    {

        return kb.fKey;

    }
    public static ButtonControl GetXButton(Keyboard kb)
    {

        return kb.eKey;

    }
    public static ButtonControl GetYButton(Keyboard kb)
    {

        return kb.qKey;

    }
    public static ButtonControl GetStartButton(Keyboard kb)
    {
        return kb.enterKey;

    }
    public static ButtonControl GetSelectButton(Keyboard kb)
    {

        return kb.backspaceKey;

    }
    public static ButtonControl GetLeftTrigger(Mouse ms)
    {

        return ms.leftButton;

    }
    public static ButtonControl GetRightTrigger(Mouse ms)
    {

        return ms.rightButton;

    }
    public static ButtonControl GetLeftShoulder(Keyboard kb)
    {

        return kb.zKey;

    }
    public static ButtonControl GetRightShoulder(Keyboard kb)
    {

        return kb.xKey;

    }
    
}
