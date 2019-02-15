using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TAction
    {
        public TAction()
        {
            TStudy = new HashSet<TStudy>();
        }

        public int IActionId { get; set; }
        public int IForceId { get; set; }
        public int IPostureId { get; set; }
        public int IHandednessId { get; set; }
        public int IObjectHandleId { get; set; }
        public int IProcedureId { get; set; }

        public virtual TForce IForce { get; set; }
        public virtual THandedness IHandedness { get; set; }
        public virtual TObjectHandle IObjectHandle { get; set; }
        public virtual TPosture IPosture { get; set; }
        public virtual TProcedure IProcedure { get; set; }
        public virtual ICollection<TStudy> TStudy { get; set; }
    }
}
