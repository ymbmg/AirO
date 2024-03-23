using System;
using System.Runtime.InteropServices;
using UnityEngine;


/// <summary>
/// An Angle struct similar to what's used in PhotonEngine's Fusion multiplayer library.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Angle : IEquatable<Angle>
{
  [FieldOffset(0)]
  private int _value;

  /// <summary>
  /// Clamps the current value to the supplied min-max range.
  /// </summary>
  public void Clamp(Angle min, Angle max)
  {
    if (_value < min._value)
      _value = min._value;
    if (_value <= max._value)
      return;
    _value = max._value;
  }

  /// <summary>Returns the smaller of two supplied angles.</summary>
  public static Angle Min(Angle a, Angle b) => a._value >= b._value ? b : a;

  /// <summary>Returns the larger of two supplied angles.</summary>
  public static Angle Max(Angle a, Angle b) => a._value <= b._value ? b : a;

  /// <summary>Lerps between two angle values.</summary>
  public static Angle Lerp(Angle a, Angle b, float t)
  {
    return a._value == b._value ? (Angle) a._value : (Angle) Mathf.LerpAngle((float) a, (float) b, t);
  }

  /// <summary>Returns a the value, clamped to the min-max range.</summary>
  public static Angle Clamp(Angle value, Angle min, Angle max)
  {
    if (max._value < min._value)
    {
      Angle angle = max;
      max = min;
      min = angle;
    }
    if (value._value < min._value)
      return min;
    return value._value > max._value ? max : value;
  }

  public static bool operator <(Angle a, Angle b) => a._value < b._value;

  public static bool operator <=(Angle a, Angle b) => a._value <= b._value;

  public static bool operator >(Angle a, Angle b) => a._value > b._value;

  public static bool operator >=(Angle a, Angle b) => a._value >= b._value;

  public static bool operator ==(Angle a, Angle b) => a._value == b._value;

  public static bool operator !=(Angle a, Angle b) => a._value != b._value;

  public bool Equals(Angle other) => this._value == other._value;

  public override bool Equals(object obj) => obj is Angle other && this.Equals(other);

  public override int GetHashCode() => this._value;

  public static Angle operator +(Angle a, Angle b)
  {
    a._value += b._value;
    if (a._value > 3600000)
      a._value %= 3600000;
    return a;
  }

  public static Angle operator -(Angle a, Angle b)
  {
    a._value -= b._value;
    if (a._value < 0)
      a._value = 3600000 + a._value;
    return a;
  }

  public static explicit operator float(Angle value) => (float) value._value / 10000f;

  public static explicit operator double(Angle value) => (double) value._value / 10000.0;

  public static implicit operator Angle(double value)
  {
    if (value > 360.0)
      value %= 360.0;
    else if (value < 0.0)
      value = value >= -360.0 ? 360.0 + value : 360.0 + value % -360.0;
    Angle angle;
    angle._value = (int) (value * 10000.0 + 0.5);
    return angle;
  }

  public static implicit operator Angle(float value) => (Angle) (double) value;

  public static implicit operator Angle(int value)
  {
    if (value > 360)
      value %= 360;
    else if (value < 0)
      value = value >= -360 ? 360 + value : 360 + value % -360;
    Angle angle;
    angle._value = value * 10000;
    return angle;
  }

  public override string ToString()
  {
    string str = (this._value % 10000).ToString();
    if (str.Length < 4)
      str = new string('0', 4 - str.Length) + str;
    return string.Format("[Angle:{0}.{1}]", (object) (this._value / 10000), (object) str);
  }
}