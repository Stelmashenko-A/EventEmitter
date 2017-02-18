using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO.Enums
{
    public enum Claim
    {
        [MapValue(Value = "a989da73-a402-4eed-b14f-522ce8382563")]
        CreateUser,

        [MapValue(Value = "7fc96047-3145-4505-9e3d-92b85e024836")]
        DeleteUser,

        [MapValue(Value = "0d3dd83c-c06b-4f2c-b071-ab164cda6eb9")]
        CreateEvent,

        [MapValue(Value = "97c1c73b-e972-4e5f-9eba-e6232c60d75a")]
        DeleteEvent,

        [MapValue(Value = "878904d7-6477-4974-8741-132b56583ac9")]
        DeleteAlienEvent,

        [MapValue(Value = "0e811228-0786-4f5e-a4e7-290aabc87e6f")]
        ModifyAlienEvent,

        [MapValue(Value = "19d9d223-ffa1-4c62-aecf-2e096c5c2573")]
        WriteComments,

        [MapValue(Value = "a6911315-c265-4375-8a77-c30e3bcb2f25")]
        ModifyComments,

        [MapValue(Value = "180c9914-573f-4821-88be-2b2f5731a1b2")]
        DeleteComment,

        [MapValue(Value = "449084a2-9b00-4b45-9a88-b98c750bc860")]
        DeleteAlienComments,

        [MapValue(Value = "1b39c2e8-b65f-41de-9cda-8ec1128b8dde")]
        ModifyAlienComments
    }
}
