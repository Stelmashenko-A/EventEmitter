using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO.Enums
{
    public enum RegistrationType
    {

        [MapValue(Value = "00000000-0000-0000-0000-000000000000")]
        None = 0,

        [MapValue(Value = "341eef50-f5ea-48ac-871b-3700a50edcae")]
        Interested = 1,

        [MapValue(Value = "7fb9fc51-07d5-4977-9d3d-8b7cbf106c7f")]
        Go = 2
    }
}