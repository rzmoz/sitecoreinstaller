using System;
using System.Xml.Serialization;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class SourceManifest : IEquatable<SourceManifest>
    {
        public SourceManifest()
        {
            Enabled = true;
        }

        [XmlAttribute]
        public bool Enabled { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string Parameters { get; set; }


        public bool Equals(SourceManifest other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(this.Name, other.Name) && string.Equals(this.Type, other.Type) && string.Equals(this.Parameters, other.Parameters);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((SourceManifest)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Parameters != null ? Parameters.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(SourceManifest left, SourceManifest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SourceManifest left, SourceManifest right)
        {
            return !Equals(left, right);
        }
    }
}
