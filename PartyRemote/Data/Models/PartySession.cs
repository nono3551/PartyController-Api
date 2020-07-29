using System;

namespace PartyRemote.Data.Models
{
    public class PartySession
    {
        private SerializationMode _serializationMode = SerializationMode.New;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string QueuePassword { get; set; }
        public string OwnerPassword { get; set; }
        public string CurrentSong { get; set; }
        public int SongsCount { get; set; }
        public DateTime CreatedAt { get; set; }

        public void SetSerializationMode(SerializationMode mode)
        {
            _serializationMode = mode;
        }

        public bool ShouldSerializeCreatedAt()
        {
            return _serializationMode != SerializationMode.New;
        }
        public bool ShouldSerializeId()
        {
            return _serializationMode != SerializationMode.New;
        }


        public bool ShouldSerializeOwnerPassword()
        {
            return _serializationMode == SerializationMode.Owner;
        }

        public enum SerializationMode
        {
            New,
            Owner,
            Guest
        }
    }
}
