using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable : IComponent
{
    void Initilize();

    void Dispose();
}
