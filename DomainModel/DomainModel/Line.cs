using System;
using System.Collections.Generic;

namespace DomainModel
{
    internal class Line : IEquatable<Line>, IComparable<Line>
    {
        private readonly string[] words;

        public Line(Line otherLine)
        {
            words = otherLine.Words;
        }

        protected Line(string[] words)
        {
            this.words = words;
        }

        public string this[int i]
        {
            get { return string.Copy(words[i]); }
            set { words[i] = value; }
        }

        public string[] Words
        {
            get 
            { 
                var newWords = new string[words.Length];
                for (var i = 0; i < words.Length; i++)
                    newWords[i] = this[i];
                return newWords;
            }
        }

        public int Length
        {
            get { return words.Length; }
        }

        public static Line Parse(string line)
        {
            var words = line.Split(' ');
            return new Line(words);
        }

        public int CompareTo(Line other)
        {
            return String.Compare(ToString(), other.ToString(), StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return string.Join(" ", words);
        }

        public bool Equals(Line other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(words, other.words);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line) obj);
        }

        public override int GetHashCode()
        {
            return (words != null ? words.GetHashCode() : 0);
        }

        public static bool operator ==(Line left, Line right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Line left, Line right)
        {
            return !Equals(left, right);
        }
    }
}
