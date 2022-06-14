using Chorus.Conductor.Sync;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AmcInterception
{
    public abstract class SyncEntityBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = GenerateId();

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Deleted { get; set; }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("D");
        }


        public virtual async Task<T> HandleConflict<T>(T serverVersion)
            where T : ISyncEntity
        {
            return serverVersion;
        }
    }
}
