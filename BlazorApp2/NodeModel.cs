using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2
{
    public abstract class NodeModel
    {
        public int Id { get; set; }

        protected abstract void SetFromProtected(NodeModel other);

        public void SetFrom(NodeModel other)
        {
            if (other != null)
            {
                Id = other.Id;
                SetFromProtected(other);
            }
        }
    }

    public class NodeModelTranslate : NodeModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        protected override void SetFromProtected(NodeModel other)
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
            return $"X={X}, Y={Y}, Z={Z}";
        }
    }

    public class NodeModelRotate : NodeModel
    {
        public NodeModelRotateType RotateType { get; set; }
        public double Angle { get; set; }

        protected override void SetFromProtected(NodeModel other)
        {
            if (other is NodeModelRotate other2)
            {
                RotateType = other2.RotateType;
                Angle = other2.Angle;
            }
        }

        public override string ToString()
        {
            return $"Rotate {RotateType} @ {Angle}deg";
        }
    }

    public enum NodeModelRotateType
    {
        X,
        Y,
        Z
    }
}
