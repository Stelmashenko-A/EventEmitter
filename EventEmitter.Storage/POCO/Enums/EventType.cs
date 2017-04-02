using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO.Enums
{
    public enum EventType
    {
        [MapValue(Value = "78e0386c-2596-44ba-8939-36221dc63806")]
        Default = 0,

        [MapValue(Value = "b5e06fe1-60f9-4883-9102-aace5836e558")]
        UseWhiteList = 1
    }
}