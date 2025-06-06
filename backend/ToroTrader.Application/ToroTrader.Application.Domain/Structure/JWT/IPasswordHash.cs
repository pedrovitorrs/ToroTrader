﻿namespace ToroTrader.Application.Domain.Structure.JWT;

public interface IPasswordHash
{
    string EncryptPassword(string password, string passwordHash);
    string GeneratePasswordHash();
    bool PasswordIsEquals(string enteredPassword, string passwordHash, string storedPassword);
}