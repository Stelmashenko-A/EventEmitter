using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO.Enums
{
    public enum RegistrationType
    {
        [MapValue(Value = "7FB9FC51-07D5-4977-9D3D-8B7CBF106C7F")]
        Go,

        [MapValue(Value = "341EEF50-F5EA-48AC-871B-3700A50EDCAE")]
        Interested      
    }
}