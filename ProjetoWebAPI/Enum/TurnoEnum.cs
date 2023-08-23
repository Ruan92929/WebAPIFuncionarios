using System.Text.Json.Serialization;

namespace ProjetoWebAPI.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manhã,
        Tarde,
        Noite
    }
}
