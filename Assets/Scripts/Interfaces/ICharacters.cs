using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICharacter
{
    float Speed { get; set; }
    float Life { get; set; }
}
public interface IKillable
{
    void Kill();
}
public interface IDamageable<T>
{
    void Damage(T damageTaken);
}

public interface IStunable<T>
{
    void Stun(T target, T stunSecond);
}

public interface ISlowable<T>
{
    void Slow(T target, T slowSecond);

}
