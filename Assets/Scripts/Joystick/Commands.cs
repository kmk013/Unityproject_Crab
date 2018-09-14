using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour {

    public List<JoystickState> commands = new List<JoystickState>();

    private void Start()
    {
        commands.Add(JoystickState.RIGHT);
    }

    public void Add(JoystickState state)
    {
        commands.Add(state);
    }

    public JoystickState Search(int index)
    {
        return commands[index];
    }
}
