using System;
using UnityEngine;


public class UpdateManager : MonoBehaviour
{
    private IUpdatable[] _updatables;

    private void Start()
    {
        _updatables = new IUpdatable[100];
    }

    public void AddUpdatable(IUpdatable element)
    {
        for (int i = 0; i < _updatables.Length; i++)
        {
            if (_updatables[i] == null)
            {
                _updatables[i] = element;
                return;
            }
        }

        var lenth = _updatables.Length;
        IUpdatable[] newArray = new IUpdatable[lenth * 2];
        for (int i = 0; i < _updatables.Length; i++)
        {
            newArray[i]=_updatables[i];
        }

        _updatables = newArray;

    }

    public void RemoveUpdatable(IUpdatable element)
    {
        for (int i = 0; i < _updatables.Length; i++)
        {
            if (_updatables[i] == element)
            {
                _updatables[i] = null;
                return;
            }
        }
    }

    private void Update()
    {
        foreach (var updatable in _updatables)
        {
            if (updatable != null)
            {
                updatable.Tick();
            }
        }
    }
}