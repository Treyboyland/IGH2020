using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringEvent : UnityEvent<string> { }

public class EmptyEvent : UnityEvent { }

public class IntEvent : UnityEvent<int> { }

public class FloatEvent : UnityEvent<float> { }

public class BoolEvent : UnityEvent<bool> { }

public class PickupEvent : UnityEvent<Pickup> { }