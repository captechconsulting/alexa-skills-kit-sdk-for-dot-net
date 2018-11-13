using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Request
{
    public enum PlayerActivity
    {
        [EnumMember(Value = "PLAYING")]
        Playing,
        [EnumMember(Value = "PAUSED")]
        Paused,
        [EnumMember(Value = "FINISHED")]
        Finished,
        [EnumMember(Value = "BUFFER_UNDERRUN")]
        BufferUnderrun,
        [EnumMember(Value = "IDLE")]
        Idle,
        [EnumMember(Value = "STOPPED")]
        Stopped
    }
}