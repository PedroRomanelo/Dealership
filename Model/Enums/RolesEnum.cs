using System.ComponentModel;

namespace Dealership.Model.Enums;

public enum RolesEnum
{
    [Description("Administrador")]
    Admin = 0,

    [Description("Suporte")]
    Support = 1,

    [Description("Financeiro")]
    Financial = 2
}