using System;
using Newtonsoft.Json;

namespace EventBus.Base.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public Guid Id { get; set; }
        [JsonProperty]
        public DateTime CreatedDate { get; set; }

        
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        
        [System.Text.Json.Serialization.JsonConstructor]
        public IntegrationEvent(DateTime createdDate, Guid id)
        {
            CreatedDate = createdDate;
            Id = id;
        }
    }
}