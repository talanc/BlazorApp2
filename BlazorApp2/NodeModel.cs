using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2
{
    public abstract class NodeModel
    {
        public int Id { get; set; }

        protected abstract void SetFromInternal(NodeModel other);

        public void SetFrom(NodeModel other)
        {
            if (other != null)
            {
                Id = other.Id;
                SetFromInternal(other);
            }
        }
    }

    public class NodeModelTranslate : NodeModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        protected override void SetFromInternal(NodeModel other)
        {
            if (other is NodeModelTranslate other2)
            {
                X = other2.X;
                Y = other2.Y;
                Z = other2.Z;
            }
        }

        public override string ToString()
        {
            return $"X={X},Y={Y},Z={Z}";
        }
    }

    public class NodeModelRotate : NodeModel
    {
        public NodeModelRotateType RotateType { get; set; }
        public double Value { get; set; }

        protected override void SetFromInternal(NodeModel other)
        {
            if (other is NodeModelRotate other2)
            {
                RotateType = other2.RotateType;
                Value = other2.Value;
            }
        }

        public override string ToString()
        {
            return $"{RotateType} @ {Value}";
        }
    }

    public enum NodeModelRotateType
    {
        X,
        Y,
        Z
    }
}
