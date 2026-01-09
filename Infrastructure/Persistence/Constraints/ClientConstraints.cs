using System;

namespace Infrastructure.Persistence.Constraints;

public static class ClientConstraints
{
    public const string UniqueName = "uq_name";
    public const string UniqueEmail = "uq_email";
}