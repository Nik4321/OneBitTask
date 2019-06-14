using System.Runtime.Serialization;

namespace OneBitTask.Data.Enums
{
    public enum Gender
    {
        [EnumMember(Value = nameof(Gender.Male))]
        Male,

        [EnumMember(Value = nameof(Gender.Female))]
        Female
    }
}
