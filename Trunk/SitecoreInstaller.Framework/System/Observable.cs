using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.System
{
  using global::System.Runtime.Serialization;

  [DataContract]
  public class Observable<T>
  {
    private T _value;

    private readonly bool _isPrimitive;

    public Observable()
    {
      var type = typeof(T);
      _isPrimitive = type.IsPrimitive;
      _notifyListeners = true;
      if (_isPrimitive)
        _setValue = ValueTypeSetter;
      else
        _setValue = ReferenceTypeSetter;
    }

    public override string ToString()
    {
      return _value.ToString();
    }

    private bool _notifyListeners;

    private readonly Func<T, bool> _setValue;
    public event EventHandler<GenericEventArgs<T>> Updating;
    public event EventHandler<GenericEventArgs<T>> Updated;

    public void Reset()
    {
      _notifyListeners = false;
      Value = default(T);
      _notifyListeners = true;
    }

    public T Value
    {
      get { return _value; }
      set { _setValue(value); }
    }

    private void SetValue(T t)
    {
      if (_notifyListeners && this.Updating != null)
        this.Updating(this, new GenericEventArgs<T>(_value));

      _value = t;

      if (_notifyListeners && this.Updated != null)
        this.Updated(this, new GenericEventArgs<T>(_value));
    }

    private bool ValueTypeSetter(T t)
    {
      if (_value.Equals(t))
        return false;
      SetValue(t);
      return true;
    }

    private bool ReferenceTypeSetter(T t)
    {
      //t will never be value type since this was decided in constructor
      if (_value as object == null && t as object == null)
        return false;

      if (_value as object != null && t as object != null && _value.Equals(t))
        return false;

      SetValue(t);
      return true;
    }
  }
}
