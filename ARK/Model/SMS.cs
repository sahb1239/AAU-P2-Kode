﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ARK.Model
{
    public class SMS : IEquatable<SMS>
    {
        public bool Dispatched { get; set; }

        public bool Handled { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        [Key]
        public string Reciever { get; set; }

        public DateTime Time { get; set; }

        public bool approved { get; set; }

        public bool Equals(SMS other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Reciever, other.Reciever);
        }

        public static bool operator ==(SMS left, SMS right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SMS left, SMS right)
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

            return Equals((SMS)obj);
        }

        public override int GetHashCode()
        {
            return Reciever != null ? Reciever.GetHashCode() : 0;
        }
    }
}