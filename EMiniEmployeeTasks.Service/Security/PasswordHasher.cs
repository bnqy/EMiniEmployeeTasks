using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.Service.Security;

public static class PasswordHasher
{
    public static byte[] Hash(string password)
    {
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool Verify(string password, byte[] storedHash)
    {
        var computedHash = Hash(password);
        return computedHash.SequenceEqual(storedHash);
    }
}