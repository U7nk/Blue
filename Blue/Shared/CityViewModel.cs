using System;
using System.ComponentModel.DataAnnotations;

namespace Blue.Shared
{
    public sealed class CityViewModel : IEquatable<CityViewModel>
    {
        public bool Equals(CityViewModel other)
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

            return Equals((CityViewModel)obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(CityViewModel left, CityViewModel right) => Equals(left, right);

        public static bool operator !=(CityViewModel left, CityViewModel right) => !Equals(left, right);

        public long Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(CityViewModelErrorLoc), ErrorMessageResourceName = "NameIsRequired")]
        [MinLength(2, ErrorMessageResourceType = typeof(CityViewModelErrorLoc), ErrorMessageResourceName = "NameTooShort")]
        public string Name { get; set; }
        [Range(0,int.MaxValue,ErrorMessageResourceType = typeof(CityViewModelErrorLoc), ErrorMessageResourceName = "CitizensIsNegative")]
        public int CitizensCount { get; set; }
        public DateTime FoundationDate { get; set; }
    }
}
