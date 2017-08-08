using System;
using System.ComponentModel.DataAnnotations;


namespace EcX.Dominio.Interface
{
    public class EntidadeGuidIDBase : IEntidade<Guid>
    {
        private int? _oldHashCode;

        [Key]
        public virtual Guid ID { get; set; }

        public virtual bool IsTransient
        {
            get
            {
                return ID == Guid.Empty;
            }
        }

        public override int GetHashCode()
        {
            if (_oldHashCode.HasValue)
                return _oldHashCode.Value;

            if (IsTransient)
            {
                _oldHashCode = base.GetHashCode();
                return _oldHashCode.Value;
            }

            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IEntidade<Guid>);
        }

        public bool Equals(IEntidade<Guid> other)
        {
            if (other == null)
            {
                return false;
            }

            if (IsTransient)
            {
                return ReferenceEquals(this, other);
            }

            return other.ID == ID;// && other.GetType() == GetType();
        }
    }
}
