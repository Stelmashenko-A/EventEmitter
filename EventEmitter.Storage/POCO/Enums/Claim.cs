namespace EventEmitter.Storage.POCO.Enums
{
    public enum Claim
    {
        [LinqToDB.Mapping.MapValue(Value = "A989DA73-A402-4EED-B14F-522CE8382563")]
        CreateUser,

        [LinqToDB.Mapping.MapValue(Value = "7FC96047-3145-4505-9E3D-92B85E024836")]
        DeleteUser,

        [LinqToDB.Mapping.MapValue(Value = "0D3DD83C-C06B-4F2C-B071-AB164CDA6EB9")]
        CreateEvent,

        [LinqToDB.Mapping.MapValue(Value = "97C1C73B-E972-4E5F-9EBA-E6232C60D75A")]
        DeleteEvent,

        [LinqToDB.Mapping.MapValue(Value = "878904D7-6477-4974-8741-132B56583AC9")]
        DeleteAlienEvent,

        [LinqToDB.Mapping.MapValue(Value = "0E811228-0786-4F5E-A4E7-290AABC87E6F")]
        ModifyAlienEvent,

        [LinqToDB.Mapping.MapValue(Value = "19D9D223-FFA1-4C62-AECF-2E096C5C2573")]
        WriteComments,

        [LinqToDB.Mapping.MapValue(Value = "A6911315-C265-4375-8A77-C30E3BCB2F25")]
        ModifyComments,

        [LinqToDB.Mapping.MapValue(Value = "180C9914-573F-4821-88BE-2B2F5731A1B2")]
        DeleteComment,

        [LinqToDB.Mapping.MapValue(Value = "449084A2-9B00-4B45-9A88-B98C750BC860")]
        DeleteAlienComments,

        [LinqToDB.Mapping.MapValue(Value = "1B39C2E8-B65F-41DE-9CDA-8EC1128B8DDE")]
        ModifyAlienComments
    }
}
