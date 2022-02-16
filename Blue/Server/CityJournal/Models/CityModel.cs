using System;

namespace Blue.Server.CityJournal.Models
{
    public sealed class CityModel : IEquatable<CityModel>
    {
        public bool Equals(CityModel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id;
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

            return Equals((CityModel)obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(CityModel left, CityModel right) => Equals(left, right);

        public static bool operator !=(CityModel left, CityModel right) => !Equals(left, right);

        public long Id { get; set; }
        public string Name { get; set; }
        public int CitizensCount { get; set; }
        public DateTime FoundationDate { get; set; }
    }
}