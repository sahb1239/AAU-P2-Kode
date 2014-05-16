﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ARK.Model
{
    public class SMS : IEquatable<SMS>
    {
        #region Public Properties

        public bool Dispatched { get; set; }

        public bool Handled { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        [Key]
        public string Reciever { get; set; }

        public DateTime Time { get; set; }

        public bool approved { get; set; }

        #endregion

        #region Public Methods and Operators

        public static bool operator ==(SMS left, SMS right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SMS left, SMS right)
        {
            return !Equals(left, right);
        }

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

            return string.Equals(this.Reciever, other.Reciever);
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

            return this.Equals((SMS)obj);
        }

        public override int GetHashCode()
        {
            return this.Reciever != null ? this.Reciever.GetHashCode() : 0;
        }

        #endregion
    }
}