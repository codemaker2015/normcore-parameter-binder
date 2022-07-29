#region License
//------------------------------------------------------------------------------ -
// Normcore-ParameterBinder
// https://github.com/chetu3319/Normcore-ParameterBinder
//------------------------------------------------------------------------------ -
// MIT License
//
// Copyright (c) 2022 Vishnu Sivan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//------------------------------------------------------------------------------ -
#endregion
using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class RealtimeFloatModel
{
   [RealtimeProperty(1, true, true)] public float _floatProperty; 
}


/* ----- Begin Normal Autogenerated Code ----- */
public partial class RealtimeFloatModel : RealtimeModel {
    public float floatProperty {
        get {
            return _floatPropertyProperty.value;
        }
        set {
            if (_floatPropertyProperty.value == value) return;
            _floatPropertyProperty.value = value;
            InvalidateReliableLength();
            FireFloatPropertyDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(RealtimeFloatModel model, T value);
    public event PropertyChangedHandler<float> floatPropertyDidChange;
    
    public enum PropertyID : uint {
        FloatProperty = 1,
    }
    
    #region Properties
    
    private ReliableProperty<float> _floatPropertyProperty;
    
    #endregion
    
    public RealtimeFloatModel() : base(null) {
        _floatPropertyProperty = new ReliableProperty<float>(1, _floatProperty);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _floatPropertyProperty.UnsubscribeCallback();
    }
    
    private void FireFloatPropertyDidChange(float value) {
        try {
            floatPropertyDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _floatPropertyProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _floatPropertyProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.FloatProperty: {
                    changed = _floatPropertyProperty.Read(stream, context);
                    if (changed) FireFloatPropertyDidChange(floatProperty);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _floatProperty = floatProperty;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
