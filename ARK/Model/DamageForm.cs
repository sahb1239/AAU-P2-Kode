﻿using System;

namespace ARK.Model
{
    public class DamageForm : IEquatable<DamageForm>
    {
        public DamageForm()
        {
            Date = DateTime.Now;
        }

        public virtual Boat Boat { get; set; }

        public int BoatId { get; set; }

        public bool Closed { get; set; }

        public DateTime Date { get; set; } // Date for the damage

        // Damagetype
        public string Description { get; set; } // Further description of the damage. what en where etc.

        public bool Functional { get; set; }

        public int Id { get; set; }

        public virtual Member RegisteringMember { get; set; }

        public int RegisteringMemberId { get; set; }

        public string Type { get; set; }

        public bool Equals(DamageForm other)
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

        public static bool operator ==(DamageForm left, DamageForm right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DamageForm left, DamageForm right)
        {
            return !Equals(left, right);
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

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((DamageForm)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}