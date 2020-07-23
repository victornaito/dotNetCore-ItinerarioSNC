using System;

namespace ItinerarioSNC.Application.Utils
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RoleAttribute: Attribute
    {
        public string[] RolesDescription { get; private set; }

        public RoleAttribute(string[] rolesDescription)
        {
            this.RolesDescription = rolesDescription;
        }

    }
}
