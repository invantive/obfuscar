#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>

// <copyright>
// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>

#endregion

using Mono.Cecil;
using System;

namespace Obfuscar
{
    /// <summary>
    /// Used to identify the signature of a method by its name and parameters.
    /// </summary>
    internal class NameParamSig : ParamSig, IComparable<NameParamSig>
    {
        public string Name { get; }

        private readonly int hashCode;

        public NameParamSig(string name, string[] paramTypes): base(paramTypes)
        {
            this.Name = name;

            this.hashCode = this.CalcHashCode();
        }

        public NameParamSig(MethodReference method): base(method)
        {
            this.Name = method.Name;
            this.hashCode = this.CalcHashCode();
        }

        public NameParamSig(MethodDefinition method): base(method)
        {
            this.Name = method.Name;
            this.hashCode = this.CalcHashCode();
        }

        private int CalcHashCode()
        {
            return this.Name.GetHashCode() ^ base.GetHashCode();
        }

        public bool Equals(NameParamSig? other)
        {
            return other != null 
                && this.Name == other.Name 
                && this.Equals((ParamSig) other)
                ;
        }

        public override bool Equals(object? obj)
        {
            return obj is NameParamSig ns ? this.Equals(ns) : false;
        }

        public static bool operator ==(NameParamSig? a, NameParamSig? b)
        {
            if ((object?)a == null)
            {
                return (object?)b == null;
            }
            else if ((object?)b == null)
            {
                return false;
            }
            else
            {
                return a.Equals(b);
            }
        }

        public static bool operator !=(NameParamSig? a, NameParamSig? b)
        {
            if ((object?)a == null)
            {
                return (object?)b != null;
            }
            else if ((object?)b == null)
            {
                return true;
            }
            else
            {
                return !a.Equals(b);
            }
        }

        public override int GetHashCode()
        {
            return this.hashCode;
        }

        public override string ToString()
        {
            return $"{this.Name}::{this.ParamTypes.Length}";
        }

        public int CompareTo(NameParamSig? other)
        {
            int cmp = string.Compare(this.Name, other?.Name);

            if (cmp == 0)
            {
                cmp = base.CompareTo(other);
            }

            return cmp;
        }
    }
}
