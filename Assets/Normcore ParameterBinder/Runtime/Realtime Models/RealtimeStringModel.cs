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
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class RealtimeStringModel
{
    [RealtimeProperty(1,true,true)]
    public string _stringProperty;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class RealtimeStringModel : RealtimeModel {
    public string stringProperty {
        get {
            return _stringPropertyProperty.value;
        }
        set {
            if (_stringPropertyProperty.value == value) return;
            _stringPropertyProperty.value = value;
            InvalidateReliableLength();
            FireStringPropertyDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(RealtimeStringModel model, T value);
    public event PropertyChangedHandler<string> stringPropertyDidChange;
    
    public enum PropertyID : uint {
        StringProperty = 1,
    }
    
    #region Properties
    
    private ReliableProperty<string> _stringPropertyProperty;
    
    #endregion
    
    public RealtimeStringModel() : base(null) {
        _stringPropertyProperty = new ReliableProperty<string>(1, _stringProperty);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _stringPropertyProperty.UnsubscribeCallback();
    }
    
    private void FireStringPropertyDidChange(string value) {
        try {
            stringPropertyDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _stringPropertyProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _stringPropertyProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.StringProperty: {
                    changed = _stringPropertyProperty.Read(stream, context);
                    if (changed) FireStringPropertyDidChange(stringProperty);
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
        _stringProperty = stringProperty;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
